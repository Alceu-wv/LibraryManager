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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Find(string email)
        {
            return _userRepository.Find(email);
        }

        public void Create(User user)
        {
            _userRepository.Add(user);
        }

        public IList<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.Find(email);

            if (user == null || !user.Password.Equals(password))
            {
                return null;
            }

            return user;
        }
    }
}
