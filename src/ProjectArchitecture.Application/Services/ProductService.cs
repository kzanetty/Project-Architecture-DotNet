using AutoMapper;
using MediatR;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Interfaces;
using ProjectArchitecture.Application.Products.Commands;
using ProjectArchitecture.Application.Products.Queries;

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

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetProductById(int? id)
        {
             var ProductByIdQuery = new GetProductByIdQuery(id.Value);

            if(ProductByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            return _mapper.Map<ProductDTO>(await _mediator.Send(ProductByIdQuery));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception("Entity could not be loaded.");
            
            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null) 
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            if (productUpdateCommand == null)
                throw new Exception("Entity could not be loaded.");


            await _mediator.Send(productUpdateCommand);
        }
    }
}
