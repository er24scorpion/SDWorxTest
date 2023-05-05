using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IBookRepository _repo;

        public GetAllBooksHandler(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetListAsync();
        }
    }
}
