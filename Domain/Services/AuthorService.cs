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
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository { get; set; }

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<long> CreateAuthorAsync(Author author)
        {
            var resp = await _authorRepository.CreateAsync(author);

            return resp;
        }

        public async Task DeleteAuthorAsync(long id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            if (authors.Count == 0)
            {
                authors = new List<Author>();
            }

            return authors;
        }

        public async Task<Author> GetAuthorAsync(long id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            return author;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var resp = await _authorRepository.UpdateAsync(author);

            return resp;
        }
    }
}
