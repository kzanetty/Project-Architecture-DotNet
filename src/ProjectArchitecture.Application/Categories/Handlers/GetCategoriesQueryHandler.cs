﻿using MediatR;
using ProjectArchitecture.Application.Categories.Queries;
using ProjectArchitecture.Domain.Entities;
using ProjectArchitecture.Domain.Interfaces;

namespace ProjectArchitecture.Application.Categories.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {

        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}
