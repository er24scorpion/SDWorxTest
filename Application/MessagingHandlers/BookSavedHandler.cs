using Domain.Events;
using Serilog;
using SlimMessageBus;

namespace Application.Handlers
{
    public class BookSavedHandler : IConsumer<BookSavedEvent>
    {
        public Task OnHandle(BookSavedEvent e)
        {
            Log.Information($"[BookSavedHandler] Book with the title \"{e.Book.Title}\" and the author \"{e.Book.Author}\" was just saved.");
            
            // some actions with the event, eg: updating db
            
            return Task.Delay(1000);
        }
    }
}
