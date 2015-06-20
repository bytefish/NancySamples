// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RestSample.Server.Infrastructure.Errors;

namespace RestSample.Server.Infrastructure.Exceptions
{
    public class UnauthorizedException : HttpServiceErrorException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public override HttpServiceError HttpServiceError
        {
            get
            {
                return HttpServiceErrorDefinition.UnauthorizedError;
            }
        }
    }
}