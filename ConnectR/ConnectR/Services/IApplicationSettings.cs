// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Services
{
    /// <summary>
    /// Defines Application-wide Settings.
    /// </summary>
    public interface IApplicationSettings
    {
        string NancyBasePath { get; }

        string SignalRBasePath { get; }

        string FileUploadDirectory { get; }

        long MaxFileUploadBytes { get; }

        int SaltSize { get; }
    }
}