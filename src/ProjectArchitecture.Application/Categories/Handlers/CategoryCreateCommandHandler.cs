using MediatR;
using ProjectArchitecture.Application.Categories.Commands;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Interfaces;

namespace ProjectArchitecture.Application.Categories.Handlers
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryCreateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            if (category == null)
            {
                throw new ApplicationException("Error creating entity");
            }
            else
            {
                return await _categoryRepository.Create(category);
            }
        }
    }
}
