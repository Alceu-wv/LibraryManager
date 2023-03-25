using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(long id);
        Task<long> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookAsync(long id);
    }
}
