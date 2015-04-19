// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RestSample.Server.Infrastructure.Web
{
    public class ServiceErrorModel
    {
        public ServiceErrorCode Code { get; set; }

        public string Details { get; set; }
    }
}