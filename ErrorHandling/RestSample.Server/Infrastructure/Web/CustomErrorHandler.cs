// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using log4net;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;

namespace RestSample.Server.Infrastructure.Web
{
    public static class CustomErrorHandler
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Enable(IPipelines pipelines, IResponseNegotiator responseNegotiator)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException("pipelines");
            }

            if (responseNegotiator == null)
            {
                throw new ArgumentNullException("responseNegotiator");
            }

            pipelines.OnError += (context, exception) => HandleException(context, exception, responseNegotiator);
        }

        private static void LogException(NancyContext context, Exception exception)
        {
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat("An exception occured during processing a request. (Exception={0}).", exception);
            }
        }

        private static Response HandleException(NancyContext context, Exception exception, IResponseNegotiator responseNegotiator)
        {
            LogException(context, exception);

            return CreateNegotiatedResponse(context, responseNegotiator, exception);
        }

        private static Response CreateNegotiatedResponse(NancyContext context, IResponseNegotiator responseNegotiator, Exception exception)
        {
            HttpServiceError httpServiceError = HttpServiceErrorUtilities.ExtractFromException(exception, HttpServiceErrorDefinition.GeneralError);

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(httpServiceError.HttpStatusCode)
                .WithModel(httpServiceError.ServiceErrorModel);

            return responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }
}