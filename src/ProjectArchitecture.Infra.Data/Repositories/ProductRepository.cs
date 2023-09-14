using Microsoft.EntityFrameworkCore;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Interfaces;
using ProjectArchitecture.Infra.Data.Context;

namespace ProjectArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<Product?> GetProductCategoryAsync(int? id)
        {
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
