// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.Serialization;

namespace RestSample.Server.Infrastructure.Errors
{
    public abstract class HttpServiceErrorException : Exception, IHasHttpServiceError
    {
        public HttpServiceErrorException() { }
        public HttpServiceErrorException(string message) : base(message) { }
        public HttpServiceErrorException(string message, System.Exception inner) : base(message, inner) { }
        protected HttpServiceErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public abstract HttpServiceError HttpServiceError { get; }
    }
}