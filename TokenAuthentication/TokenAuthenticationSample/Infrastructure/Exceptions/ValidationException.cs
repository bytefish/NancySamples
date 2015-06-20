// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Validation;
using RestSample.Server.Infrastructure.Errors;
using System;
using System.Collections.Generic;

namespace RestSample.Server.Infrastructure.Web.Exceptions
{
    public class ValidationException : HttpServiceErrorException
    {
        public readonly IDictionary<string, IList<ModelValidationError>> Errors;

        public ValidationException(IDictionary<string, IList<ModelValidationError>> errors)
            : base()
        {
            if (errors == null)
            {
                throw new ArgumentNullException("errors");
            }
            Errors = errors;
        }
        
        private string GetErrorMessage() 
        {
            return string.Format("Validation failed. Properties: ({0})", string.Join(", ", Errors.Keys));
        }
        
        public override HttpServiceError HttpServiceError
        {
            get {
                return new HttpServiceError()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    ServiceErrorModel = new ServiceErrorModel()
                    {
                        Code = ServiceErrorCode.ValidationError,
                        Details = GetErrorMessage()
                    }
                };
            }
        }
    }
}