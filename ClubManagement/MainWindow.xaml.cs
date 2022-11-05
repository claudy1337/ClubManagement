using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClubManagement.Data.Classes;
using ClubManagement.Data.Model;
using ClubManagement.Pages;
using ClubManagement.Windws;
using ClubManagement.Pages.TeacherControl;
using ClubManagement.Pages.AdminControl;

namespace ClubManagement
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User CurrentUser;
        public MainWindow(User currnetUser)
        {
            CurrentUser = currnetUser;
            InitializeComponent();
            if (DBMethodsFromUser.GetAdminRole(CurrentUser.Authorization.Login) == false)
            {
                clControl.Visibility = Visibility.Hidden;
                clStatistics.Visibility = Visibility.Hidden;
            }
            else
            {
                clStudent.Visibility = Visibility.Hidden;
                clSections.Visibility = Visibility.Hidden;
            }
            txtWelcome.Text = $"Welcome: {CurrentUser.Role.Title} " + CurrentUser.Name;
            fContainer.Navigate(new AccountPage(CurrentUser));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private void minus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void clAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainer.Navigate(new AccountPage(CurrentUser));
        }
        private void clExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void clControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainer.Navigate(new ControlPage(CurrentUser));
        }

        private void clStatistics_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void clStudent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainer.Navigate(new StudentPage(CurrentUser));
        }

        private void clSections_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
