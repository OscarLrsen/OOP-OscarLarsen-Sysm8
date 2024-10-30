using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterBTN(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string countryBox = (CountryBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string email = Email.Text;
            string password = PasswordHolder.Password;

            if (ValidateInput(firstName, lastName, countryBox, email, password))
            {
                User newUser = new User(email, password) { FirstName = firstName, LastName = lastName, CountryBox = countryBox };

                MainWindow mainWindow = new MainWindow(newUser);
                mainWindow.Show();
                this.Close();

            }
        }
        private bool ValidateInput(string firstName, string lastName, string country, string email, string password)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                ErrorName.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                ErrorName.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                ErrorLastName.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                ErrorLastName.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(country))
            {
                ErrorComboBox.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                ErrorComboBox.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ErrorEmail.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                ErrorEmail.Visibility = Visibility.Hidden;
            }

            if (password.Length < 8 || !password.Any(char.IsDigit) || !password.Any(char.IsPunctuation))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                ErrorBorder.Visibility = Visibility.Hidden;
            }

            return isValid;
        }



            private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void FirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                FirstNamePlacer.FontSize = 12;
                FirstNamePlacer.Margin = new Thickness(5, 0, 35, 0);
            }
        }

        private void FirstName_GotFocus(object sender, RoutedEventArgs e)

        {
            FirstNamePlacer.FontSize = 10;
            FirstNamePlacer.Margin = new Thickness(5, -15, 35, 0);
            
        }

        private void LastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LastName.Text))
            {
                LastNamePlacer.FontSize = 12;
                LastNamePlacer.Margin = new Thickness(5, 0, 35, 0);
            }
        }

        private void LastName_GotFocus(object sender, RoutedEventArgs e)
        {
            LastNamePlacer.FontSize = 10;
            LastNamePlacer.Margin = new Thickness(5, -15, 35, 0);

        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailPlacer.FontSize = 10;
            EmailPlacer.Margin = new Thickness(5, -15, 35, 0);
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text)) 
            {
                EmailPlacer.FontSize = 12;
                EmailPlacer.Margin = new Thickness(5, 0, 35, 0);
            }
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordHolder.Visibility == Visibility.Visible)
            {
                VisiblePasswordBox.Text = PasswordHolder.Password;
                PasswordHolder.Visibility = Visibility.Collapsed;
                VisiblePasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordHolder.Password = VisiblePasswordBox.Text;
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
                PasswordHolder.Visibility = Visibility.Visible;
            }
        }
    }
}
