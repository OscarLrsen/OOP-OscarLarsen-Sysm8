using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fitrack.Class
{
    class Admin
    {
        private List <User> users;

        public Admin()
        {
            users = new List<User>
            {
                new User("admin", "password", true),
                new User("user", "password")

            };

        }
        public User Authenticate(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsAdminEmail(string email)
        {
            return users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Admin);
        }

        public void AddUser(User user)
        {
            users.Add(user);    
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
