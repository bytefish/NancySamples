using System;
using RestSample.Server.Infrastructure.Web;

namespace RestSample.Server.Infrastructure.Exceptions
{
    public class InvalidTokenErrorException : Exception, IHasHttpServiceError
    {
        public InvalidTokenErrorException()
            : base() { }

        public InvalidTokenErrorException(string message)
            : base(message) { }

        public InvalidTokenErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpServiceError HttpServiceError { get { return HttpServiceErrorDefinition.InvalidTokenError; } }
    }
}