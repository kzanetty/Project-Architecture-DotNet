using AutoMapper;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Products.Commands;

namespace ProjectArchitecture.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
