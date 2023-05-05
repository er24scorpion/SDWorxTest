using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetListAsync();
        public Task<Book> GetByIdAsync(int id);
        public Task<Book> AddAsync(Book book);
        public Task<int> UpdateAsync(Book book);
        public Task<int> DeleteAsync(int id);
    }
}
