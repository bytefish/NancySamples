// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using System.Collections.Generic;

namespace ConnectR.Requests
{
    public class FileUploadRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<string> Tags { get; set; }

        public HttpFile File { get; set; }
    }
}