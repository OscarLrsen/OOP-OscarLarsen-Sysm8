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


        public UserDetailsWindow(User loggedInUser)
        {
            InitializeComponent();
            user = loggedInUser;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(loggedInUser);
            mainWindow.Show();
            this.Close();
        }
    }
}

