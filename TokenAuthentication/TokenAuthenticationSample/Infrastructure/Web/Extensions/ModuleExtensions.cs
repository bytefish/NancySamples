// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;
using RestSample.Server.Infrastructure.Web.Exceptions;

namespace RestSample.Server.Infrastructure.Web.Extensions
{
    public static class ModuleExtensions
    {
        public static TModel CustomBindAndValidate<TModel>(this NancyModule module)
        {
            TModel model = module.Bind<TModel>();
            InternalValidate(module, model);
            return model;
        }

        private static void InternalValidate<TModel>(NancyModule module, TModel model)
        {
            if (model != null)
            {
                var modelValidationResult = module.Validate(model);
                if (!modelValidationResult.IsValid)
                {
                    throw new ValidationException(modelValidationResult.Errors);
                }
            }
        }
    }
}