// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RestSample.Server.Infrastructure.Errors
{
    public class ServiceErrorModel
    {
        public ServiceErrorCode Code { get; set; }

        public string Details { get; set; }

        public override string ToString()
        {
            return string.Format("ServiceErrorModel (Code: {0}, Details: {1})", Code, Details);
        }
    }
}