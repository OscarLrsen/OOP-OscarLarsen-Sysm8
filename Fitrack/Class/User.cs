using Fitrack.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Fitrack.Class.Admin;

namespace Fitrack
{
    public class User
    {
        public string Email { get; set; } // Egenskap för användarens e-postadress
        public string Password { get; set; }// Egenskap för användarens lösenord
        public string FirstName { get; set; }// Egenskap för användarens förnamn
        public string LastName { get; set; } // Egenskap för användarens efternamn
        public string CountryBox { get; set; } //Lagrar användarens land
        public bool Admin { get; set; }// Egenskap som indikerar om användaren har admin rättigheter
        public List<Admin.Workout> Workouts { get; set; } // Lista över användarens träningspass

        public User(string email, string password, bool admin = false) // Konstruktor som initierar en användare med e-post, lösenord och adminstatus
        {
            Email = email;
            Password = password;
            Admin = admin;
            Workouts = new List<Admin.Workout>();
        }




    }

}
