using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
