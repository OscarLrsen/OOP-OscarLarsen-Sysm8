using Fitrack.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fitrack
{
    /// <summary>
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        private User user;
        public AddWorkoutWindow(User loggedInUser)
        {
            InitializeComponent();
            user = loggedInUser;
        }
        private void AddWorkout(string workoutType, DateTime date)
        {
            user.Workouts.Add(new Admin.Workout(date, workoutType));
        }
    }
}
