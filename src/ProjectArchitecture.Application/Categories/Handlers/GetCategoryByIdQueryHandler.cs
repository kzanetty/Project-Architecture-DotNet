using MediatR;
using ProjectArchitecture.Application.Categories.Queries;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Interfaces;

namespace ProjectArchitecture.Application.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByIdAsync(request.Id);

        }
    }
}
