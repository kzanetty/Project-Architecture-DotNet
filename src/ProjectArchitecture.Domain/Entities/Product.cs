using ProjectArchitecture.Domain.Validation;

namespace ProjectArchitecture.Domain.Entities
{
    public sealed class Product : EntityBase
    {

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateId(id);
            ValidateDomain(name, description, price, stock, image);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image {  get; private set; }

        // Essas propriedades de navegação não fazem parte do modelo de dominio. Logo não precisam dos privates
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. To short, minimum 3 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description. To short, minimum 5 characters.");
            DomainExceptionValidation.When(price < 0, "Invalid price value.");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image. To long, maximum 250 characters.");

            Name = name;
            Description = description;  
            Price = price;
            Stock = stock;
            Image = image;
        }

        private void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0 , "Invalid Id value.");
            Id = id;
        }
    }
}
