using MediatR;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Application.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
