using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RepositoryContext _dbContext;

        public BookRepository(RepositoryContext repositoryContext)
        {
            _dbContext = repositoryContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            var result = _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var filteredData = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            if (filteredData == null) return -1;

            _dbContext.Books.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetListAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<int> UpdateAsync(Book book)
        {
            _dbContext.Books.Update(book);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
