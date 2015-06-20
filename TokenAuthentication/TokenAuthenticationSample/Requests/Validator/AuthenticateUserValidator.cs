// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation;
using RestSample.Server.Infrastructure.Validation;

namespace RestSample.Server.Requests.Validator
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserRequest>
    {
        public AuthenticateUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .Length(1, 255)
                .IsAlphaNumeric();

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(1, 255);
        }
    }
}