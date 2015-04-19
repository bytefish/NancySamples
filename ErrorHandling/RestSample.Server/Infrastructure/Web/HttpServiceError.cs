// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;

namespace RestSample.Server.Infrastructure.Web
{
    public class HttpServiceError
    {
        public ServiceErrorModel ServiceErrorModel { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
} 