using ProjectArchitecture.Domain.Validation;

namespace ProjectArchitecture.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            ValidateId(id);
            ValidateDomain(name);
        }

        public string Name { get; private set; }
        //essa coleção deve ter o private?
        public ICollection<Product> Products { get; set; }
        //
        public void Update(string name)
        {
            ValidateDomain(name);

        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. To short, minimum 3 characters.");
            Name = name;
        }
        private void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
        }
    }
}
