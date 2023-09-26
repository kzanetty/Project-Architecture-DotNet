using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
