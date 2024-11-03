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
        private User user;
        private User loggedInUser;
        private Admin.Workout workout;




        public WorkoutDetailsWindow(Admin.Workout workout, User loggedInUser)
        {
            InitializeComponent();
            this.workout = workout;
            this.loggedInUser = loggedInUser;
            LoadWorkoutDetails();
        }

        private void LoadWorkoutDetails()
        {
            DatePicker.SelectedDate = workout.Date;
            TypeTextBox.Text = workout.WorkoutType;
            DurationTextBox.Text = workout.Duration.ToString(); 
            NotesTextBox.Text = workout.Notes;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DatePicker.IsEnabled = true;
            TypeTextBox.IsReadOnly = false;
            DurationTextBox.IsReadOnly = false;
            NotesTextBox.IsReadOnly = false;  
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate.HasValue && int.TryParse(DurationTextBox.Text, out int duration))
            {
                workout.Date = DatePicker.SelectedDate.Value;
                workout.WorkoutType = TypeTextBox.Text;
                workout.Duration = duration;
                workout.Notes = NotesTextBox.Text;

                // Öppna Workouts_Window och stäng nuvarande fönster
                Workouts_Window workouts_Window = new Workouts_Window(loggedInUser);
                workouts_Window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vänligen fyll i alla fält korrekt.");
            }
        }

    }
}
