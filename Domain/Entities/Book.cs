using Domain.Events;
using SlimMessageBus;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public async Task Submit()
        {
            var e = new BookSavedEvent(this);
            await MessageBus.Current.Publish(e);
        }
    }
}
