using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;

        public UserRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }

        public User Find(string email)
        {
            return _dbContext.User.FirstOrDefault(u => u.Email.Equals(email));
        }

        public IList<User> GetAll()
        {
            return _dbContext.User.ToList();
        }
    }
}
