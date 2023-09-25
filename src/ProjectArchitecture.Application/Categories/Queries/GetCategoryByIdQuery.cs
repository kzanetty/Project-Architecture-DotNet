using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
