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
using static Fitrack.Class.Admin;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fitrack
{
    /// <summary>
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        private User user;
        private User loggedInUser;
        private Admin.Workout workout;



        public AddWorkoutWindow(User loggedInUser)
        {
            InitializeComponent();
            user = loggedInUser;
            this.loggedInUser = loggedInUser;
            workout = new Admin.Workout(DateTime.Now, "");
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
            SaveButton.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate.HasValue &&
               int.TryParse(DurationTextBox.Text, out int duration))
            {
                var newWorkout = new Admin.Workout
                (
                    date: DatePicker.SelectedDate.Value,
                    workoutType: TypeTextBox.Text,
                    duration: duration,
                    notes: NotesTextBox.Text
                );
                
                 loggedInUser.Workouts.Add(newWorkout);


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
