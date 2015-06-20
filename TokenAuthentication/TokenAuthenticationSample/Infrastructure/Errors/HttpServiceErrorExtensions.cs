// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace RestSample.Server.Infrastructure.Errors
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