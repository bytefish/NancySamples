// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;
using RestSample.Server.Infrastructure.Database;
using RestSample.Server.Infrastructure.Web.ErrorHandling;
using RestSample.Server.Services;
using DatabaseFactory = RestSample.Server.Infrastructure.Database.DatabaseFactory;


namespace RestSample.Server
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(config => {
                    config.ResponseProcessors = new [] { typeof(JsonProcessor), typeof(XmlProcessor) };
                });
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IMappingProvider, MappingProvider>();
            container.Register<IConnectionStringProvider, ConnectionStringProvider>();
            container.Register<IApplicationSettings, ApplicationSettings>();
            container.Register<ICryptoService, CryptoService>();
            container.Register<IDatabaseFactory, DatabaseFactory>();
            container.Register<IAuthService, DatabaseAuthService>();
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            CustomErrorHandler.Enable(pipelines, container.Resolve<IResponseNegotiator>());
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
        }
    }
}
