using MediatR;

namespace Application.Commands
{
    public record UpdateBookCommand(int Id, string Title, string Author) : IRequest<int>
    {
    }
}
