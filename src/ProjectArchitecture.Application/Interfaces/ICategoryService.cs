using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int? id);
        Task Add(CreateCategoryRequest request);
        Task Update(UpdateCategoryRequest request);
        Task Remove(int? id);
    }
}
