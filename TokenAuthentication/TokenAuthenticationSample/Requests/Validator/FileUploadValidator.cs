// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation;
using RestSample.Server.Services;
using RestSample.Server.Infrastructure.Validation;

namespace RestSample.Server.Request.Validator
{
    /// <summary>
    /// Validates a PhotoUploadRequest.
    /// </summary>
    public class FileUploadValidator : AbstractValidator<FileUploadRequest>
    {
        public FileUploadValidator(IApplicationSettings settings)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            long maxUploadSize = settings.MaxFileUploadBytes;

            RuleFor(x => x.Title)
                .NotNull()
                .Length(1, 2000);
            
            RuleFor(x => x.Tags)
                .NotNull()
                .LengthBetweenInclusiveBounds(1, 5)
                .All(x => LengthBetweenInclusive(x, 0, 255), "Invalid Tag Length");
            
            RuleFor(x => x.Description)
                .Length(1, 2000)
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
            
            RuleFor(x => x.File)
                .NotNull()
                .Must((request, file) => request.ContentSize < maxUploadSize)
                .WithMessage(GetFileSizeExceededMessage(maxUploadSize));
        }

        private string GetFileSizeExceededMessage(long maximumFileSize)
        {
            return string.Format("Maximum file size of {0} bytes exceeded.", maximumFileSize);
        }

        private bool LengthBetweenInclusive(string s, int min, int max)
        {
            if(s.Length >= min && s.Length <= max)
            {
                return true;
            }
            return false;
        }
    }
}