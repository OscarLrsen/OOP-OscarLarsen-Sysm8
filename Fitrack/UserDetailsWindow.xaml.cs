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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    
    public partial class UserDetailsWindow : Window
    {
        private User user;
        private User loggedInUser;
        private Admin admin;


        public UserDetailsWindow(User loggedInUser, Admin admin)
        {
            InitializeComponent();
            user = loggedInUser;
            this.loggedInUser = loggedInUser;
            this.admin = admin ?? new Admin();      
            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            UsernameTextBox.Text = loggedInUser.Email;
            CountryBox.SelectedItem = CountryBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == loggedInUser.CountryBox);

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = UsernameTextBox.Text;
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string newCountry = (CountryBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(newUsername) || newUsername.Length < 3)
            {
                MessageBox.Show("Användarnamnet måste vara minst 3 tecken långt.", "Error");
                return;
            }
            if (admin.GetUsers().Any(u => u.Email == newUsername && u != loggedInUser))
            {
                MessageBox.Show("Användarnamnet är redan upptaget.", "Error");
                return;
            }
            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword) || newPassword.Length < 5)
            {
                if (newPassword.Length < 5 && confirmPassword.Length < 5)
                {
                    MessageBox.Show("Lösenordet måste vara minst 5 tecken långt.", "Varning");
                    return;
                }
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Lösenorden matchar inte.", "Varning");
                    return;
                }
                loggedInUser.Password = newPassword;

            }
            loggedInUser.Email = newUsername;
            loggedInUser.CountryBox = newCountry;
            MessageBox.Show("Användaruppgifterna har uppdaterats!", "Sparat");


            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }
    }
}

