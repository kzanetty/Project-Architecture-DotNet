using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int? id); // Avaliar se nullable é viavel ou não
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
}
