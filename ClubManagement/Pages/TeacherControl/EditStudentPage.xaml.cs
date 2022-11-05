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
using ClubManagement.Pages;
using System.IO;

namespace ClubManagement.Pages.TeacherControl
{
    /// <summary>
    /// Логика взаимодействия для EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : Page
    {
        public static User CurrentUser;
        public EditStudentPage(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }

        private void lstvStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectStudent = lstvStudent.SelectedItem as Student;
        }
    }
}
