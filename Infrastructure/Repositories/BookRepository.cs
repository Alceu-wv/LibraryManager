using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext _libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<long> CreateAsync(Book book)
        {
            await _libraryDbContext.AddAsync(book);
            await _libraryDbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task DeleteAsync(long id)
        {
            var book = await _libraryDbContext.Books.SingleAsync(b => b.Id == id);

            _libraryDbContext.Books.Remove(book);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _libraryDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(long id)
        {
            var book = await _libraryDbContext.Books.FindAsync(id);

            if (book == null)
            {
                throw new InvalidOperationException("ID does not exist on database!");
            }

            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var baseBook = await _libraryDbContext.Books.AsNoTracking().SingleAsync(b => b.Id == book.Id);

            baseBook.Title = book.Title;
            baseBook.ISBN = book.ISBN;
            baseBook.ReleaseYear = book.ReleaseYear;

            _libraryDbContext.Books.Update(baseBook);
            await _libraryDbContext.SaveChangesAsync();

            return baseBook;
        }
    }
}
