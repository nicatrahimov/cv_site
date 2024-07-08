using System.ComponentModel.DataAnnotations;

namespace NijatRahimov_CV_Site.Attributes;

    internal sealed class AllowedExtensionsAttribute(params string[] extensions) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not IFormFile file)
            {
                return ValidationResult.Success;
            }

            var extension = Path.GetExtension(file.FileName);
            if (!extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult("Unsupported file extension");
            }
            return ValidationResult.Success;
        }
    }