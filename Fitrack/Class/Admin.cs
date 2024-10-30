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
                new User("admin", "“password", true)
            };

        }
        public User Authenticate(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
