// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using System.Collections.Generic;

namespace RestSample.Server
{
    /// <summary>
    /// Request for uploading a file.
    /// </summary>
    public class FileUploadRequest
    {
        /// <summary>
        /// Title of the file.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the file.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Tags to be associated with the file.
        /// </summary>
        public IList<string> Tags { get; set; }

        /// <summary>
        /// The file, that should be uploaded.
        /// </summary>
        public HttpFile File { get; set; }
        
        /// <summary>
        /// The Size of the Content coming with this Request.
        /// </summary>
        public long ContentSize { get; set; }
    }
}