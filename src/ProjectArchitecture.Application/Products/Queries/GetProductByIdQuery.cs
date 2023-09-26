using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
