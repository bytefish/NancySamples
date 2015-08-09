// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Infrastructure.Authentication;
using ConnectR.Model;
using ConnectR.Requests;

namespace ConnectR.Services
{
    public interface IAuthService
    {
        void Register(RegisterUserRequest register);

        bool TryAuthentifcate(Credentials request, out UserIdentity identity);
    }
}