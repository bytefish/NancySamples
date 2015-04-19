using System;
using Nancy;
using System.Runtime.Serialization;

namespace RestSample.Server.Infrastructure.Web
{
    public class ServiceErrorModel
    {
        public ServiceErrorCode Code { get; set; }

        public string Details { get; set; }
    }
}