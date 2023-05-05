using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBookRepository _repo;

        public UpdateBookHandler(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _repo.GetByIdAsync(command.Id);
            if (book == null) return default;

            book.Title = command.Title;
            book.Author = command.Author;
            var res = await _repo.UpdateAsync(book);
            
            await book.Submit();
            return res;
        }
    }
}
