using FluentValidation;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MinimumLength(3)
                .WithMessage("Invalid name. To short, minimum 3 characters.");
        }
    }
}
