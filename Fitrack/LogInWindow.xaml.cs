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
            if (string.IsNullOrEmpty(TextHolder.Text))
            {
                TextHolder.FontSize = 14;
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
            if (string.IsNullOrEmpty(TextHolder.Text))
            {
                EmailPlacer.FontSize = 14;
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
