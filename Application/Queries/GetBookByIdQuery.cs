using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public record GetBookByIdQuery(int Id) : IRequest<Book>
    {
    }
}
