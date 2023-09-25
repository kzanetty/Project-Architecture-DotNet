using AutoMapper;
using ProjectArchitecture.Application.Categories.Commands;
using ProjectArchitecture.Application.Products.Commands;
using ProjectArchitecture.Application.Requests;

namespace ProjectArchitecture.Application.Mappings
{
    public class RequestToCommandMappingProfile : Profile
    {
        public RequestToCommandMappingProfile()
        {
            CreateMap<CreateProductRequest, ProductCreateCommand>();
            CreateMap<UpdateProductRequest, ProductUpdateCommand>();
            CreateMap<CreateCategoryRequest, CategoryCreateCommand>();
            CreateMap<UpdateCategoryRequest, CategoryUpdateCommand>();
        }
    }
}
