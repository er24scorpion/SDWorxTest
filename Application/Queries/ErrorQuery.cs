using MediatR;

namespace Application.Queries
{
    public record ErrorQuery : IRequest<int>
    {
    }
}
