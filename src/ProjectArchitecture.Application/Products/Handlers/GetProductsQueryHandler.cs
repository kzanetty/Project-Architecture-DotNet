using MediatR;
using ProjectArchitecture.Application.Products.Queries;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Interfaces;

namespace ProjectArchitecture.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
