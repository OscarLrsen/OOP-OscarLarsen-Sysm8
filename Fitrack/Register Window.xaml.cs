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
    /// Interaction logic for Register_Window.xaml
    /// </summary>
    public partial class Register_Window : Window
    {
        public Register_Window()
        {
            InitializeComponent();
        }

        private void TogglePasswordVisibilty(object sender, RoutedEventArgs e)
        {

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
    }
}
