using FluentAssertions;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Validation;

namespace ProjectArchitecture.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name", "Product Description", 850.40m, 76, "Product Image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product("P", "Product Description", 850.40m, 76, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. To short, minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_LongoImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product("Product name", "Product Description", 850.40m, 76, "In the vast and ever-expanding realm of modern technology, where innovation and progress are the driving forces, we find ourselves navigating a complex and interconnected web of information, where data flows like a mighty river, and the boundaries of what is possible are constantly being pushed to new frontiers, reshaping the way we live, work, and interact with the world around us, and as we embrace the challenges and opportunities of this digital age, we must remain vigilant, ethical, and responsible stewards of this powerful tool, ensuring that it serves the greater good and enriches our lives while safeguarding against its potential pitfalls and unintended consequences.");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image. To long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product("Product name", "Product Description", 850.40m, 76, null);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product("Product name", "Product Description", 850.40m, 76, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product("Product name", "Product Description", 850.40m, 76, "");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product("Product name", "Product Description", -850.40m, 76, "Product Description");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Fact]
        public void CreateProduct_WithNegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product("Product name", "Product Description", 850.40m, -76, "Product Description");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

    }
}
