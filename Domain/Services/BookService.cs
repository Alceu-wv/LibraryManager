using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository { get; set; }

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<long> CreateBookAsync(Book book)
        {
            var resp = await _bookRepository.CreateAsync(book);

            return resp;
        }

        public async Task DeleteBookAsync(long id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            if (books.Count == 0)
            {
                books = new List<Book>();
            }

            return books;
        }

        public async Task<Book> GetBookAsync(long id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var resp = await _bookRepository.UpdateAsync(book);

            return resp;
        }
    }
}
