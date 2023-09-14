using ProjectArchitecture.Infra.Data.Context;
using ProjectArchitecture.Domain.Interfaces;
using ProjectArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectArchitecture.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> Create(Category category)
        {
            _categoryContext.Categories.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        //Revisar o retorno desse método, tratamento de null
        public async Task<Category?> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Categories.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Categories.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
