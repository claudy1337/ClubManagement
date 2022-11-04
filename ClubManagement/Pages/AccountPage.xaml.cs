using ClubManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
using ClubManagement.Pages;

namespace ClubManagement.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public static User CurrentUser;
        public AccountPage(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            if (DBMethodsFromUser.GetAdminRole(CurrentUser.Authorization.Login) == false)
            {
                txtName.IsReadOnly = true;
                txtPatronymic.IsReadOnly = true;
                txtSurname.IsReadOnly = true;
            }
            BindingData();
        }
        private void BindingData()
        {
            if (CurrentUser.Image == null)
            {
                imgUser.Source = new BitmapImage(new Uri("/Resources/default_user.png", UriKind.RelativeOrAbsolute));
            }
            this.DataContext = CurrentUser;
        }
        private void imgUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DBMethodsFromUser.EditImageUser(CurrentUser);
            NavigationService.Navigate(new AccountPage(CurrentUser));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtPatronymic.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    MessageBox.Show("заполните все поля");
                }
                else
                {
                    DBMethodsFromUser.EditAccount(CurrentUser, txtName.Text, txtSurname.Text, txtPatronymic.Text);
                }
            }
            catch (FormatException)
            {
                return;
            }
        }
    }
}
