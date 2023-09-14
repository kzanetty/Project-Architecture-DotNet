using ProjectArchitecture.Domain.Entities;
using System;

namespace ProjectArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int? id); // Avaliar se nullable é viavel ou não
        Task<Product?> GetProductCategoryAsync(int? id); // Avaliar se nullable é viavel ou não
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
