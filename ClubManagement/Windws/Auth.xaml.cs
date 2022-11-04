using ClubManagement.Data.Classes;
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
using ClubManagement.Data.Model;
using ClubManagement.Pages;

namespace ClubManagement.Windws
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public static User CurrentUser;
        public Auth()
        {
            InitializeComponent();
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

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("заполните все поля");
                return;
            }
            else
            {
                if (DBMethodsFromUser.IsCorrectUser(txtLogin.Text, txtPassword.Password))
                {
                    CurrentUser = DBMethodsFromUser.CurrentUser;
                    MainWindow main = new MainWindow(CurrentUser);
                    MessageBox.Show($"Welcome: {CurrentUser.Name}");
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("не верные данные");
                    return;
                }
            }
        }
    }
}
