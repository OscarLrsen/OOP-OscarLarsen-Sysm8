﻿using Fitrack.Class;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fitrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        private User loggedInUser; //Användarens data
        private Admin admin = new Admin(); //Instans av Admin klassen


        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(User user) // Konstruktor för inloggad användare

        {
            InitializeComponent();
            loggedInUser = user;
            UpdateUserInfo();

        }

        private void UpdateUserInfo() // Uppdaterar gränssnittet med användarens information

        {
            if (loggedInUser != null)
            {
                // Sätt för- och efternamnet som knapptext eller annan plats i gränssnittet
                UserNameButton.Content = $"{loggedInUser.FirstName} {loggedInUser.LastName}";

                // Dölj Log In och Sign In-knapparna om de visas
                LogInButton.Visibility = Visibility.Collapsed;
                SignInButton.Visibility = Visibility.Collapsed;

                //Visa workouts knappen i gränssnittet
                WorkoutWindow.Visibility = Visibility.Visible;
                // Visa användarens information i gränssnittet
                UserNameButton.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            LogInWindow logInWindow = new LogInWindow();
            logInWindow.Show();
            this.Close();
        }

        private void RegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void UserName_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow(loggedInUser, admin);
            userDetailsWindow.Show();
            this.Close();
        }

        private void WorkoutWindow_Click(object sender, RoutedEventArgs e)
        {
            Workouts_Window workouts_Window = new Workouts_Window(loggedInUser);
            workouts_Window.Show();
            this.Close();
        }
    }
}