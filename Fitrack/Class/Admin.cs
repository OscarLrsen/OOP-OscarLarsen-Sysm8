using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fitrack.Class
{
    public class Admin
    {
        private List <User> users; // Lista som innehåller alla användare

        public Admin() // Konstruktor som initierar standardanvändare och lägger till exempelträningar
        {
            users = new List<User>
            {
                new User("admin", "password", true),
                new User("user", "password")

            };
            var user = users.FirstOrDefault(u => u.Email == "user"); // Lägger till exempelträningar för användaren med e-post "user"
            if (user != null)
            {
                user.Workouts.Add(new Workout(DateTime.Now.AddDays(1), "Chest"));
                user.Workouts.Add(new Workout(DateTime.Now.AddDays(3), "Back"));
            }

        }
        public User Authenticate(string email, string password)// Metod för att autentisera en användare baserat på e-post och lösenord

        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsAdminEmail(string email)// Kontrollera om e-postadressen tillhör en administratör
        {
            return users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Admin);
        }

        public void AddUser(User user) // Metod för att lägga till en ny användare till listan
        {
            users.Add(user);    
        }

        public List<User> GetUsers() // Hämtar alla användare
        {
            return users;
        }

        public List<Workout> GetAllWorkouts() // Hämtar alla träningspass från alla användare
        {
            return users.SelectMany(u => u.Workouts).ToList();
        }



        public class Workout // Inre klass för att representera ett träningspass
        {
            public DateTime Date { get; set; }
            public string WorkoutType { get; set; }
            public int Duration { get; set; }
            public string Notes { get; set; }

            public Workout(DateTime date, string workoutType, int duration = 0, string notes = "")
            {
                Date = date;
                WorkoutType = workoutType;
                Duration = duration;
                Notes = notes;

            }

            public void UpdateWorkout(DateTime date, string workoutType, int duration, string notes)
                // Konstruktor som initierar ett träningspass med datum, typ, varaktighet och anteckningar
            {
                Date = date;
                WorkoutType = workoutType;
                Duration = duration;
                Notes = notes;
            }

            public override string ToString() //Override för att returnera en kort beskrivning av träningspasset
            {
                return $"{WorkoutType} on {Date.ToShortDateString()}, Duration: {Duration} mins.";
            }

        }


    }
}
