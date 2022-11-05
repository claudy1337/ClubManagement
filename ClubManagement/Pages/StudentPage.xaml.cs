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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClubManagement.Data.Model;
using ClubManagement.Data.Classes;
using ClubManagement.Pages.TeacherControl;

namespace ClubManagement.Pages.TeacherControl
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public static User CurrentUser;
        public StudentPage(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }

        private void clAddStudent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerStudentControl.Navigate(new AddStudentPage());
        }

        private void clControlStudent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerStudentControl.Navigate(new ControlStudentPage(CurrentUser));
        }

        private void clEditStudent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerStudentControl.Navigate(new EditStudentPage(CurrentUser));
        }
    }
}
