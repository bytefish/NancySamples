// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;

namespace ConnectR.Requests.Binding
{
    /// <summary>
    /// Do not pollute the Module. Use a custom Model Binder to extract the binding part.
    /// </summary>
    public class FileUploadRequestBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
        {
            var fileUploadRequest = (instance as FileUploadRequest) ?? new FileUploadRequest();

            var form = context.Request.Form;

            fileUploadRequest.Tags = GetTags(form["tags"]);
            fileUploadRequest.Title = form["title"];
            fileUploadRequest.Description = form["description"];
            fileUploadRequest.File = GetFileByKey(context, "file");

            return fileUploadRequest;
        }

        private IList<string> GetTags(dynamic field)
        {
            try
            {
                var tags = (string)field;
                return tags.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return new List<string>();
            }
        }

        private HttpFile GetFileByKey(NancyContext context, string key)
        {
            IEnumerable<HttpFile> files = context.Request.Files;
            if (files != null)
            {
                return files.FirstOrDefault(x => x.Key == key);
            }
            return null;
        }

        public bool CanBind(Type modelType)
        {
            return modelType == typeof(FileUploadRequest);
        }
    }
}