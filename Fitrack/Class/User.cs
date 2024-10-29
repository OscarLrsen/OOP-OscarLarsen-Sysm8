using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitrack
{
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Admin { get; set; }

        public User(string email, string password, bool admin = false)
        {
            Email = email;
            Password = password;
            Admin = admin;
        }


    }
}
