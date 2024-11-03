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
    /// Interaction logic for Workouts_Window.xaml
    /// </summary>
    public partial class Workouts_Window : Window
    {

        private User loggedInUser;
        private Admin admin = new Admin();

        public Workouts_Window(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            UpdateUserInfo();
            LoadWorkouts();
        }

        private void LoadWorkouts()
        {
            Console.WriteLine("Antal träningspass: " + loggedInUser.Workouts.Count);
            WorkoutListView.ItemsSource = null;
            WorkoutListView.ItemsSource = loggedInUser.Workouts;

            if (loggedInUser.Admin)
            {
                // Om användaren är admin, ladda alla träningspass från alla användare
                WorkoutListView.ItemsSource = admin.GetAllWorkouts();
            }
            else
            {
                // Om användaren inte är admin, ladda enbart densne egna träningspass
                WorkoutListView.ItemsSource = loggedInUser.Workouts;
            }
        }
        private void UpdateUserInfo()
        {
            if (loggedInUser != null)
            {
                // Sätt för- och efternamnet som knapptext eller annan plats i gränssnittet
                UserNameText.Text = $"{loggedInUser.FirstName} {loggedInUser.LastName}";

                // Visa användarens information i gränssnittet
                UserNameText.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }

        private void UserDetailsButton(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow(loggedInUser, admin);
            userDetailsWindow.Show();
            this.Close();

        }

        private void OpenAddWorkoutWindow(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow(loggedInUser);
            addWorkoutWindow.Show();
            this.Close();
        }

        private void RemoveWorkout(object sender, RoutedEventArgs e)
        {
            if (WorkoutListView.SelectedItem is Admin.Workout selectedWorkout)
            {
                if (loggedInUser.Admin)
                {
                    var ownerUser = admin.GetUsers().FirstOrDefault(u => u.Workouts.Contains(selectedWorkout));
                    ownerUser?.Workouts.Remove(selectedWorkout);
                }
                else
                {
                    loggedInUser.Workouts.Remove(selectedWorkout);
                }

                LoadWorkouts();  
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void ShowWorkoutDetails(object sender, RoutedEventArgs e)
        {

            if (WorkoutListView.SelectedItem is Admin.Workout selectedWorkout)
            {
                WorkoutDetailsWindow workoutDetailsWindow = new WorkoutDetailsWindow(selectedWorkout, loggedInUser);
                workoutDetailsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a workout to view details.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("FitTrack helps you not get fat.", 
                    "FitTrack Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
