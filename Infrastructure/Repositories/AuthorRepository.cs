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
    public class AuthorRepository : IAuthorRepository
    {
        private LibraryDbContext _libraryDbContext { get; set; }

        public AuthorRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<long> CreateAsync(Author author)
        {
            await _libraryDbContext.AddAsync(author);
            await _libraryDbContext.SaveChangesAsync();

            return author.Id;
        }

        public async Task DeleteAsync(long id)
        {
            var author = await _libraryDbContext.Authors.SingleAsync(a => a.Id == id);

            _libraryDbContext.Authors.Remove(author);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _libraryDbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(long id)
        {
            var author = await _libraryDbContext.Authors.FindAsync(id);

            if (author == null)
            {
                throw new InvalidOperationException("ID does not exist on database!");
            }

            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            var baseAuthor = await _libraryDbContext.Authors.AsNoTracking().SingleAsync(a => a.Id == author.Id);

            baseAuthor.FirstName = author.FirstName;
            baseAuthor.LastName = author.LastName;
            baseAuthor.Email = author.Email;
            baseAuthor.BirthDate = author.BirthDate;

            _libraryDbContext.Authors.Update(baseAuthor);
            await _libraryDbContext.SaveChangesAsync();

            return baseAuthor;
        }
    }
}
