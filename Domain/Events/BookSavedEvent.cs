using Domain.Entities;

namespace Domain.Events
{
    public record BookSavedEvent(Book Book) 
    {
        public DateTime Timestamp { get; } = DateTime.UtcNow;
    }
}
