using FluentValidation;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Validators
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {

            RuleFor(request => request.Id)
               .NotEmpty()
               .WithMessage("Id is required.")
               .GreaterThan(0)
               .WithMessage("Invalid Id. Id must be greater than zero.")
               .Must(id => IsNumeric(id.ToString()))
               .WithMessage("Invalid Id. Id must be a numeric value.");

            RuleFor(request => request.Name)
               .NotEmpty()
               .WithMessage("Name is required.")
               .MinimumLength(3)
               .WithMessage("Invalid name. To short, minimum 3 characters.");
        }

        private static bool IsNumeric(string value) 
            => int.TryParse(value, out _);
        
    }
}
