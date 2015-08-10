// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Services
{
    /// <summary>
    /// Notifies listeners about a new Upload.
    /// </summary>
    public interface IUploadNotificationService
    {
        void OnFileUploaded(string fileName);
    }
}
