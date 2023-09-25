using AutoMapper;
using MediatR;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Interfaces;
using ProjectArchitecture.Application.Products.Commands;
using ProjectArchitecture.Application.Products.Queries;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(CreateProductRequest request)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(request)
                ?? throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetProductById(int? id)
        {
             var ProductByIdQuery = new GetProductByIdQuery(id.Value)
                ?? throw new Exception("Entity could not be loaded.");

            var productSelected = await _mediator.Send(ProductByIdQuery);

            return _mapper.Map<ProductDTO>(productSelected);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery()
                ?? throw new Exception("Entity could not be loaded.");

            return _mapper.Map<IEnumerable<ProductDTO>>(await _mediator.Send(productsQuery));
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value)
                ?? throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(UpdateProductRequest request)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(request)
                ?? throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productUpdateCommand);
        }
    }
}
