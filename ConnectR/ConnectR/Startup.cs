
using ConnectR.Hubs;
using ConnectR.Infrastructure.Database;
using ConnectR.Infrastructure.SignalR;
using ConnectR.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Cors;
using Nancy.Owin;
using Nancy.TinyIoc;
using Owin;

namespace ConnectR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            TinyIoCContainer container = new TinyIoCContainer();

            RegisterDependencies(container);
            
            SetupSignalR(app, container);

            SetupNancy(app, container);
        }

        private void RegisterDependencies(TinyIoCContainer container)
        {
            // Make some Registrations:
            container.Register<IMappingProvider, MappingProvider>();
            container.Register<IDatabaseFactory, DatabaseFactory>();
            container.Register<IConnectionStringProvider, ConnectionStringProvider>();
            container.Register<IApplicationSettings, ApplicationSettings>();
            container.Register<ICryptoService, CryptoService>();
            container.Register<IAuthService, DatabaseAuthService>();
            container.Register<IChatService, LoggingChatService>();


            // Register Hubs:
            container.Register<LoggingHubPipelineModule>();
            container.Register<ChatHub>();
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