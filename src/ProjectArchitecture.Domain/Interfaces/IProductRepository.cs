using ProjectArchitecture.Domain.Entities;
using System;

namespace ProjectArchitecture.Domain.Interfaces
{
    interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int? id); // Avaliar se nullable é viavel ou não
        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Remove(Product category);
    }
}
