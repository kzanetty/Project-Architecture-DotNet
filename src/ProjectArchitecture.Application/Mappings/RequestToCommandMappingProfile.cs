using AutoMapper;
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

        }
    }
}
