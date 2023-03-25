using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorAsync(long id);
        Task<long> CreateAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(long id);
    }
}
