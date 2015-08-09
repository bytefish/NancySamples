// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Security;
using System.Security.Claims;

namespace ConnectR.Infrastructure.Nancy
{
    public class ConnectRModule : NancyModule
    {
        public ConnectRModule()
            : base()
        {
        }

        public ConnectRModule(string modulePath)
            : base(modulePath)
        {
        }

        protected ClaimsPrincipal Principal
        {
            get { return this.Context.GetMSOwinUser(); }
        }
    }
}
