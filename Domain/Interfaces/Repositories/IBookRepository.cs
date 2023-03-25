using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(long id);
        Task<long> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task DeleteAsync(long id);
    }
}
