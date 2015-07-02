// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Requests;
using Nancy.Security;

namespace ConnectR.Services
{
    public interface IAuthService
    {
        void Register(RegisterUserRequest register);

        bool TryAuthentifcate(AuthenticateUserRequest request, out IUserIdentity identity);
    }
}