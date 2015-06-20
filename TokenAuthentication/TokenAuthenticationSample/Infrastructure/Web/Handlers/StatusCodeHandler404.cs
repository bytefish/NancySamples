// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses.Negotiation;
using RestSample.Server.Infrastructure.Errors;
using RestSample.Server.Infrastructure.Web.Extensions;

namespace RestSample.Server.Infrastructure.Web.Handlers
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
              .WithHttpServiceError(HttpServiceErrorDefinition.NotFoundError);
                        
            context.Response = responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }
}