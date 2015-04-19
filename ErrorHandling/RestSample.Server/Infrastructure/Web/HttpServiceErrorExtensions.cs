using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSample.Server.Infrastructure.Web
{
    public static class HttpServiceErrorUtilities
    {
        public static HttpServiceError ExtractFromException(Exception exception, HttpServiceError defaultValue)
        {
            HttpServiceError result = defaultValue;

            if (exception != null)
            {
                IHasHttpServiceError exceptionWithServiceError = exception as IHasHttpServiceError;

                if (exceptionWithServiceError != null)
                {
                    result = exceptionWithServiceError.HttpServiceError;
                }
            }

            return result;
        }
    }
}