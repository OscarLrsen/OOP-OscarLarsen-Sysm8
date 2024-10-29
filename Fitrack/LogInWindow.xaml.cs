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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextHolder.FontSize = 10;
            TextHolder.Margin = new Thickness(5, -15, 35, 0);
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordHolder.Password))
            {
                TextHolder.FontSize = 12;
                TextHolder.Margin = new Thickness(5, 0, 35, 0);
            }
        }

        private void EmailHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailPlacer.FontSize = 10;
            EmailPlacer.Margin = new Thickness(5, -15, 35, 0);
        }

        private void EmailHolder_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EmailHolder.Text))
            {
                EmailPlacer.FontSize = 12;
                EmailPlacer.Margin = new Thickness(5, 0, 35, 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordHolder.Visibility == Visibility.Visible)
            {
                // Visa TextBox och kopiera lösenordet till den
                VisiblePasswordBox.Text = PasswordHolder.Password;
                PasswordHolder.Visibility = Visibility.Collapsed;
                VisiblePasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                // Visa PasswordBox och kopiera tillbaka lösenordet till den
                PasswordHolder.Password = VisiblePasswordBox.Text;
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
                PasswordHolder.Visibility = Visibility.Visible;
            }
        }

        private void LogInBTN(object sender, RoutedEventArgs e)
        {
            string email = EmailHolder.Text;
            string password = PasswordHolder.Password;

            Fitrack.Class.Admin admin = new Fitrack.Class.Admin();
            User user = admin.Authenticate(email, password);

            if (user != null && user.Admin) 
            {
                Workouts_Window workouts_Window = new Workouts_Window();
                workouts_Window.Show();
                this.Close();
            }
            else
            {
                ErrorEmail.Visibility = Visibility.Visible;
                ErrorPassword.Visibility = Visibility.Visible;
            }
        }


        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void ImageMainWindow(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
