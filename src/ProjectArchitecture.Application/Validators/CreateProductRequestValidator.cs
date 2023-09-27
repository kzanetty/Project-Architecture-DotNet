using FluentValidation;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MinimumLength(3)
                .WithMessage("Invalid name. To short, minimum 3 characters.")
                .MaximumLength(100)
                .WithMessage("Invalid name. To long, maximum 100 characters.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("The Description is required.")
                .MinimumLength(5)
                .WithMessage("Invalid Description. To short, minimum 5 characters.")
                .MaximumLength(200)
                .WithMessage("Invalid Description. To long, maximum 200 characters.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("The Price is required.")
                .Must(x => x >= 0)
                .WithMessage("The price field must be a non-negative value.")
                .Must(x => x == 0 || Math.Round(x, 2) == x)
                .WithMessage("The price field must have up to two decimal places.");


            RuleFor(p => p.Stock)
                .NotEmpty()
                .WithMessage("The Stock field is required.")
                .InclusiveBetween(1, 9999)
                .WithMessage("The Stock field must be a number between 1 and 9999.");

            // Verificar se está RULE está se comportando como o esperado
            // Image pode ser Null or Empty
            RuleFor(p => p.Image)
                .MaximumLength(250)
                .WithMessage("Invalid Image. To long, maximum 250 characters.");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .WithMessage("The CategoryId field is required.")
                .Must(id => IsNumeric(id.ToString()))
                .WithMessage("Invalid CategoryId. Id must be a numeric value.");
        }

         private static bool IsNumeric(string value)
            => int.TryParse(value, out _);
    }
}
