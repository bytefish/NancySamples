using System;
using RestSample.Server.Infrastructure.Web;

namespace RestSample.Server.Infrastructure.Exceptions
{
    public class GeneralServiceErrorException : Exception, IHasHttpServiceError
    {
        public GeneralServiceErrorException()
            : base() { }

        public GeneralServiceErrorException(string message)
            : base(message) { }

        public GeneralServiceErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpServiceError HttpServiceError { get { return HttpServiceErrorDefinition.GeneralError; } }
    }
}