using System;
using Nancy;

namespace RestSample.Server.Infrastructure.Web
{
    public class HttpServiceError
    {
        public ServiceErrorModel ServiceErrorModel { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
} 