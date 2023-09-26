using FluentAssertions;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Validation;

namespace ProjectArchitecture.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category("Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category("a");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. To short, minimum 3 characters.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category("");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(null);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }
    }
}