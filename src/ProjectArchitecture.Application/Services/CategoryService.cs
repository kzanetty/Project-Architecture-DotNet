using AutoMapper;
using MediatR;
using ProjectArchitecture.Application.Categories.Commands;
using ProjectArchitecture.Application.Categories.Queries;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Interfaces;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Add(CreateCategoryRequest request)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(request)
                ?? throw new Exception("Entity could not be loaded.");

            var categoryCreated = await _mediator.Send(categoryCreateCommand);
            return _mapper.Map<CategoryDTO>(categoryCreated);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesQuery = new GetCategoriesQuery()
                ?? throw new Exception("Entity could not be loaded.");

            var categories = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {

            var getCategoryByIdQuery = new GetCategoryByIdQuery(id.Value)
                ?? throw new Exception("Entity could not be loaded.");

            var category = await _mediator.Send(getCategoryByIdQuery);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Remove(int? id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value)
                ?? throw new Exception("Entity could not be loaded.");

            await _mediator.Send(categoryRemoveCommand);
        }

        public async Task<CategoryDTO> Update(UpdateCategoryRequest request)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(request)
                ?? throw new Exception("Entity could not be loaded.");

            var changedCategory = await _mediator.Send(categoryUpdateCommand);
            return _mapper.Map<CategoryDTO>(changedCategory);
        }
    }
}
