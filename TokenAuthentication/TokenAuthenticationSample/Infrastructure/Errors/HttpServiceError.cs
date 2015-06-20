// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;

namespace RestSample.Server.Infrastructure.Errors
{
    public class HttpServiceError
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ServiceErrorModel ServiceErrorModel { get; set; }

        public override string ToString()
        {
            return string.Format("HttpServiceError (HttpStatusCode: {0}, ServiceErrorModel: {1})", HttpStatusCode, ServiceErrorModel);
        }
    }
} 