﻿using Fitrack.Class;
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
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryBox { get; set; }
        public bool Admin { get; set; }
        public List<Admin.Workout> Workouts { get; set; }

        public User(string email, string password, bool admin = false)
        {
            Email = email;
            Password = password;
            Admin = admin;
            Workouts = new List<Admin.Workout>();
        }




    }

}
