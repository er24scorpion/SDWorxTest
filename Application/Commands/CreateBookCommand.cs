using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public record CreateBookCommand(string Title, string Author) : IRequest<Book>
    {
    }
}
