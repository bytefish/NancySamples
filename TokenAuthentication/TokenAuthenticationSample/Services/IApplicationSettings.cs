// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RestSample.Server.Services
{
    public interface IApplicationSettings
    {
        string FileUploadDirectory { get; }

        long MaxFileUploadBytes { get; }

        int SaltSize { get; }
    }
}