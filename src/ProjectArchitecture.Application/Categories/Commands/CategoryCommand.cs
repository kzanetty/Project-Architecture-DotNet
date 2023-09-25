using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Categories.Commands
{
    public class CategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
