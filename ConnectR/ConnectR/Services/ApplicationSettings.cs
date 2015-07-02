// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Services
{

    /// <summary>
    /// Hardcoded Settings. Switch this implementation with your configurable version which 
    /// loads a Configuration from an external file, app config or database.
    /// </summary>
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

        public string NancyBasePath
        {
            get
            {
                return "/api";
            }
        }

        public string SignalRBasePath
        {
            get
            {
                return "/signalr";
            }
        }
    }
}