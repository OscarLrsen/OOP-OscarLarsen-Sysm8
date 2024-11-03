using Fitrack.Class; // Importerar nödvändiga namespaces för Admin och User klass
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
        private User user; //Användarens data 
        private User loggedInUser; //Håller data om den inloggade
        private Admin.Workout workout; //Håller data om träningspasset




        public WorkoutDetailsWindow(Admin.Workout workout, User loggedInUser) //Konstruktor som tar emot ett workout objekt
        {
            InitializeComponent();
            this.workout = workout;
            this.loggedInUser = loggedInUser;
            LoadWorkoutDetails();
        }

        private void LoadWorkoutDetails() // Metod för att fylla in detaljerna för träningspasset i inputfält
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

        private void EditButton_Click(object sender, RoutedEventArgs e) //Click knapp för hantera edit funktionen
        {
            DatePicker.IsEnabled = true;
            TypeTextBox.IsReadOnly = false;
            DurationTextBox.IsReadOnly = false;
            NotesTextBox.IsReadOnly = false;  
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) //Hanterar saveknappen och sparar redigerad träningsdetaljer
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
