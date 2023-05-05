using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IBookRepository _repo;

        public DeleteBookHandler(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _repo.GetByIdAsync(command.Id);
            if (book == null) return default;

            return await _repo.DeleteAsync(command.Id);
        }
    }
}
