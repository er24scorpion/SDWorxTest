﻿using Domain.Entities;
using Domain.Events;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _repo;

        public CreateBookHandler(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            // could use autoMapper
            var res = await _repo.AddAsync(new Book
            {
                Title = command.Title,
                Author = command.Author
            });

            // Uncomment here to test error handling
            //throw new Exception("Something went wrong during creating a book");

            await SlimMessageBus.MessageBus.Current.Publish(new BookSavedEvent(res));

            return res;
        }
    }
}
