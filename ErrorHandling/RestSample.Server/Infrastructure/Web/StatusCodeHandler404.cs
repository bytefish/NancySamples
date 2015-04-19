// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses.Negotiation;

namespace RestSample.Server.Infrastructure.Web
{
    public class StatusCodeHandler404 : IStatusCodeHandler
    {
        private IResponseNegotiator responseNegotiator;

        public StatusCodeHandler404(IResponseNegotiator responseNegotiator)
        {
            this.responseNegotiator = responseNegotiator;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.NegotiationContext = new NegotiationContext();

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(HttpServiceErrorDefinition.NotFoundError.HttpStatusCode)
                .WithModel(HttpServiceErrorDefinition.NotFoundError.ServiceErrorModel);
                        
            context.Response = responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }
}