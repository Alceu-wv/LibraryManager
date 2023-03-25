using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public User()
        {
            IsAdmin = false;
        }

        public User(long id, string name, string email, string password, bool isAdmin)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
        }
    }
}
