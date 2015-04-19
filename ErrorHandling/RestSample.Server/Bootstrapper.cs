// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using RestSample.Server.Infrastructure.Web;

namespace RestSample.Server
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(config => {
                    config.StatusCodeHandlers = new[] { typeof(StatusCodeHandler404), typeof(StatusCodeHandler500) };
                    config.ResponseProcessors = new [] { typeof(JsonProcessor), typeof(XmlProcessor) };
                });
            }
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            CustomErrorHandler.Enable(pipelines, container.Resolve<IResponseNegotiator>());
        }
    }
}