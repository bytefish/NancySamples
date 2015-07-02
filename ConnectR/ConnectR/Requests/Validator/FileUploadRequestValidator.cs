using ConnectR.Services;
using FluentValidation;
using System.Linq;

namespace ConnectR.Requests.Validator
{
    /// <summary>
    /// Validates a FileUploadRequest.
    /// </summary>
    public class FileUploadRequestValidator : AbstractValidator<FileUploadRequest>
    {
        public FileUploadRequestValidator(IApplicationSettings settings)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            RuleFor(x => x.Title)
                .NotNull()
                .Length(1, 2000);

            RuleFor(x => x.Description)
                .Length(1, 2000)
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.Tags)
                .NotNull()
                .Must(x => x.All(s => LengthBetweenInclusive(s, 0, 255)));
        }

        private bool LengthBetweenInclusive(string s, int min, int max)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            if (s.Length >= min && s.Length <= max)
            {
                return true;
            }

            return false;
        }
    }
}
