// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Infrastructure.Nancy;
using ConnectR.Requests;
using ConnectR.Services;
using Nancy;
using Nancy.ModelBinding;

namespace ConnectR.Modules
{
    public class AuthModule : ConnectRModule
    {
        private IAuthService authService;

        public AuthModule(IAuthService authService)
            : base("auth")
        {
            this.authService = authService;

            Post["/register"] = x =>
            {
                var request = this.Bind<RegisterUserRequest>();

                authService.Register(request);

                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}