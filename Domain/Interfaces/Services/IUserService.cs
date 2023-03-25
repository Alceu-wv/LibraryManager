using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
    {
        public interface IUserService
        {
            User Find(string Email);
            void Create(User User);
            IList<User> GetAll();
            User Login(string email, string password);
        }
}
