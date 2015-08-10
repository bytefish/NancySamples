// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Hubs;
using ConnectR.Infrastructure.Authentication;
using ConnectR.Infrastructure.Database;
using ConnectR.Infrastructure.SignalR;
using ConnectR.Security;
using ConnectR.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Nancy.Owin;
using Nancy.TinyIoc;
using Owin;
using System;

namespace ConnectR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            TinyIoCContainer container = new TinyIoCContainer();

            RegisterDependencies(container);

            app.UseCors(CorsOptions.AllowAll);

            SetupAuth(app, container);
            SetupSignalR(app, container);
            SetupNancy(app, container);
        }

        private void RegisterDependencies(TinyIoCContainer container)
        {
            // Make some Registrations:
            container.Register<IMappingProvider, MappingProvider>();
            container.Register<IConnectionStringProvider, ConnectionStringProvider>();
            container.Register<IDatabaseFactory, DatabaseFactory>().AsSingleton(); // Don't instantiate twice. 
            container.Register<IApplicationSettings, ApplicationSettings>();
            container.Register<ICryptoService, CryptoService>();
            container.Register<IAuthService, DatabaseAuthService>();
            container.Register<IChatService, LoggingChatService>();
            container.Register<IUploadNotificationService, SignalRUploadNotificationService>();

            // Register Hubs:
            container.Register<LoggingHubPipelineModule>();
            container.Register<ChatHub>();
        }

        private void SetupAuth(IAppBuilder app, TinyIoCContainer container)
        {
            var settings = container.Resolve<IApplicationSettings>();

            // Register a Token-based Authentication for the App:            
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // you should use this for debugging only
                TokenEndpointPath = new PathString(settings.TokenEndpointBasePath),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new SimpleAuthorizationServerProvider(container.Resolve<IAuthService>())
            });

            // Use default options:
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
            {
                Provider = new OAuthTokenProvider(
                    req => req.Query.Get("bearer_token"),
                    req => req.Query.Get("access_token"),
                    req => req.Query.Get("token"),
                    req => req.Headers.Get("X-Token"))
            });
        }

        private void SetupNancy(IAppBuilder app, TinyIoCContainer container)
        {
            var settings = container.Resolve<IApplicationSettings>();

            app.Map(settings.NancyBasePath, siteBuilder => siteBuilder.UseNancy(cfg => cfg.Bootstrapper = new Bootstrapper(container)));
        }

        private void SetupSignalR(IAppBuilder app, TinyIoCContainer container)
        {
            var settings = container.Resolve<IApplicationSettings>();

            // Resolve from the container shared with Nancy:
            var resolver = new TinyDependencyResolver(container);

            // Register the ConnectionManager. Can this be done in a different way?
            var connectionManager = resolver.Resolve<IConnectionManager>();
            container.Register<IConnectionManager>(connectionManager);

            SetupHubPipeline(resolver);

            app.MapSignalR(settings.SignalRBasePath, new HubConfiguration()
            {
                EnableDetailedErrors = true,
                Resolver = resolver
            });
        }

        private void SetupHubPipeline(IDependencyResolver resolver)
        {
            var hubPipeline = resolver.Resolve<IHubPipeline>();

            // Add some basic logging:
            hubPipeline.AddModule(resolver.Resolve<LoggingHubPipelineModule>());
        }
    }
}