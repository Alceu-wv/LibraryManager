using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(long id);
        Task<long> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task DeleteAsync(long id);
    }
}
