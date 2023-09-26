using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int? id);
        Task Add(CreateProductRequest request);
        Task Update(UpdateProductRequest request);
        Task Remove(int? id);
    }
}
