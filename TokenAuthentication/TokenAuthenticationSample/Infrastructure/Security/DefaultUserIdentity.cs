// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Security;
using System.Collections.Generic;

namespace RestSample.Server.Infrastructure.Security
{
    public class DefaultUserIdentity : IUserIdentity
    {
        public DefaultUserIdentity(string userName, IEnumerable<string> claims)
        {
            UserName = userName;
            Claims = claims;
        }

        public string UserName { get; private set; }

        public IEnumerable<string> Claims { get; private set; }
    }
}