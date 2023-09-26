using AutoMapper;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<Product, ProductDTO>()
                .ForMember(prod => prod.Category,
                            opt => opt.MapFrom(src => src.Category != null ? CategoryMapper.ToCategoryDTO(src.Category) : null));
        }
    }
}
