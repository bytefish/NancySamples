// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Responses.Negotiation;
using RestSample.Server.Infrastructure.Errors;

namespace RestSample.Server.Infrastructure.Web.Extensions
{
    public static class NegotiatorExtensions
    {
        public static Negotiator WithHttpServiceError(this Negotiator neogiator, HttpServiceError error)
        {
            return neogiator
              .WithStatusCode(error.HttpStatusCode)
              .WithModel(error.ServiceErrorModel);
        }
    }
}