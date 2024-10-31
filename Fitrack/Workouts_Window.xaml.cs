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

        public Workouts_Window()
        {
            InitializeComponent();
        }

        private void UserNameButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateUserInfo()
        {
            if (loggedInUser != null)
            {
                // Sätt för- och efternamnet som knapptext eller annan plats i gränssnittet
                UserNameButton.Content = $"{loggedInUser.FirstName} {loggedInUser.LastName}";

                // Visa användarens information i gränssnittet
                UserNameButton.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
