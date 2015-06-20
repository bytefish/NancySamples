// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;
using RestSample.Server.Infrastructure.Exceptions;
using RestSample.Server.Infrastructure.Web.Extensions;
using RestSample.Server.Requests;
using RestSample.Server.Responses;
using RestSample.Server.Services;

namespace RestSample.Server.Modules
{
    public class AuthModule : NancyModule
    {
        private ITokenizer tokenizer;
        private IAuthService authService;

        public AuthModule(ITokenizer tokenizer, IAuthService authService)
            : base("auth")
        {
            this.tokenizer = tokenizer;
            this.authService = authService;

            Post["/token"] = x =>
            {
                var request = this.CustomBindAndValidate<AuthenticateUserRequest>();
                var identity = GetUserIdentity(request);
                var response = GetAuthenticateResponse(identity);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            };

            Post["/register"] = x =>
            {
                var request = this.CustomBindAndValidate<RegisterUserRequest>();

                authService.Register(request);

                var response = new RegisterUserResponse();

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            };
        }

        private AuthenticateUserResponse GetAuthenticateResponse(IUserIdentity userIdentity)
        {
            var token = tokenizer.Tokenize(userIdentity, Context);

            return new AuthenticateUserResponse
            {
                Token = token
            };
        }

        private IUserIdentity GetUserIdentity(AuthenticateUserRequest request)
        {
            IUserIdentity userIdentity;
            if (!authService.TryAuthentifcate(request, out userIdentity))
            {
                throw new UnauthorizedException();
            }
            return userIdentity;
        }
    }
}