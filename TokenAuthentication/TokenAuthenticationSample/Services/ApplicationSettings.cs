// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RestSample.Server.Services
{
    public class ApplicationSettings : IApplicationSettings
    {
        public long MaxFileUploadBytes
        {
            get { return 10485760; }
        }

        public int SaltSize
        {
            get { return 13;  }
        }

        public string FileUploadDirectory
        {
            get { return "uploads"; }
        }
    }
}