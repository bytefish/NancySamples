// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using RestSample.Server.Infrastructure.Exceptions;

namespace RestSample.Server
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["unhandled"] = parameters =>
            {
                throw new System.InvalidOperationException("An invalid operation exception.");
            };

            Get["token"] = parameters =>
            {
                throw new InvalidTokenErrorException("The User had an invalid token.");
            };
        }
    }
}