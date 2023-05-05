using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public record GetAllBooksQuery() : IRequest<List<Book>>
    {
    }
}
