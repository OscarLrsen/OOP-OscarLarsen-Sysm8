using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fitrack.Class
{
    public class Admin
    {
        private List <User> users;

        public Admin()
        {
            users = new List<User>
            {
                new User("admin", "password", true),
                new User("user", "password")

            };
            var user = users.FirstOrDefault(u => u.Email == "user");
            if (user != null)
            {
                user.Workouts.Add(new Workout(DateTime.Now.AddDays(1), "Chest"));
                user.Workouts.Add(new Workout(DateTime.Now.AddDays(3), "Back"));
            }

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

        public List<Workout> GetAllWorkouts()
        {
            return users.SelectMany(u => u.Workouts).ToList();
        }



        public class Workout
        {
            public DateTime Date { get; set; }
            public string WorkoutType { get; set; }

            public Workout(DateTime date, string workoutType)
            {
                Date = date;
                WorkoutType = workoutType;
            }

        }


    }
}
