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

        public Workouts_Window(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            UpdateUserInfo();
            LoadWorkouts();
        }

        private void LoadWorkouts()
        {
            WorkoutListView.ItemsSource = null;
            WorkoutListView.ItemsSource = loggedInUser.Workouts;
        }

        private void UserNameButton_Click(object sender, RoutedEventArgs e)
        {

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
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow(loggedInUser);
            userDetailsWindow.Show();
        }

        private void OpenAddWorkoutWindow(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow(loggedInUser);
            addWorkoutWindow.Show();
        }

        private void RemoveWorkout(object sender, RoutedEventArgs e)
        {
            if (WorkoutListView.SelectedItem is Class.Admin.Workout selectedWorkout)
            {
                loggedInUser.Workouts.Remove(selectedWorkout);
                LoadWorkouts();
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowWorkoutDetails(object sender, RoutedEventArgs e)
        {
            if (WorkoutListView.SelectedItem is Class.Admin.Workout selectedWorkout)
            {
                WorkoutDetailsWindow workoutDetailsWindow = new WorkoutDetailsWindow(selectedWorkout);
                workoutDetailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a workout to view details.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
