// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Security;
using RestSample.Server.Requests;

namespace RestSample.Server.Services
{
    public interface IAuthService
    {
        void Register(RegisterUserRequest register);

        bool TryAuthentifcate(AuthenticateUserRequest request, out IUserIdentity identity);
    }
}