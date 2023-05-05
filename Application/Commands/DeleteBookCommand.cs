using MediatR;

namespace Application.Commands
{
    public record DeleteBookCommand(int Id) : IRequest<int>
    {
    }
}
