using ConnectR.Infrastructure.Nancy;
using ConnectR.Requests;
using ConnectR.Responses;
using ConnectR.Services;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.IO;

namespace ConnectR.Modules
{
    public class FileUploadModule : ConnectRModule
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
                FileUploadRequest request = this.BindAndValidate<FileUploadRequest>();
                FileUploadResponse response = StoreImage(request);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            };
        }

        // TODO Move to separate service.
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

        // TODO Move to separate service.
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
