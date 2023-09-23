using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
