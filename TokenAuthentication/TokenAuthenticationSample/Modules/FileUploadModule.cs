// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Security;
using RestSample.Server.Infrastructure.Web.Extensions;
using RestSample.Server.Responses;
using RestSample.Server.Services;
using System;
using System.IO;

namespace RestSample.Server.Modules
{
    public class FileUploadModule : NancyModule
    {
        private IRootPathProvider rootPathProvider;
        private IApplicationSettings applicationSettings;

        public FileUploadModule(IRootPathProvider rootPathProvider, IApplicationSettings applicationSettings)
            : base("/file")
        {
            this.rootPathProvider = rootPathProvider;
            this.applicationSettings = applicationSettings;

            Post["/upload"] = parameters =>
            {
                this.RequiresAuthentication();

                FileUploadRequest request = this.CustomBindAndValidate<FileUploadRequest>();
                FileUploadResponse response = StoreImage(request);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            };
        }
                
        private FileUploadResponse StoreImage(FileUploadRequest request)
        {
            var uploadId = Guid.NewGuid().ToString();
            var filename = Path.Combine(GetUploadDirectory(), uploadId);
            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
                request.File.Value.CopyTo(fileStream);
            }
            return new FileUploadResponse()
            {
                Id = uploadId
            };
        }

        private string GetUploadDirectory()
        {
            var uploadDirectory = Path.Combine(rootPathProvider.GetRootPath(), applicationSettings.FileUploadDirectory);

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            return uploadDirectory;
        }
    }
}