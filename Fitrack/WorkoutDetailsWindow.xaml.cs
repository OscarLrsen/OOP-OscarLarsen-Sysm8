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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        private Admin.Workout workout;
        private User loggedInUser;


        public WorkoutDetailsWindow(Admin.Workout selectedWorkout)
        {
            InitializeComponent();
            workout = selectedWorkout;
            DisplayWorkoutDetails();
        }

        private void DisplayWorkoutDetails()
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }
    }
}
