using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Mappings
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToCategoryDTO(Category category)
        {
            var categoryDTO = new CategoryDTO()
            {
                Name = category.Name,
                Id = category.Id
            };

            return categoryDTO;
        }
    }
}
