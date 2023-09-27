using FluentValidation;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            
        }
    }
}
