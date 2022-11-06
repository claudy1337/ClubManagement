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
            BindingData();
            lstvStudent.ItemsSource = DBConnection.connect.Student.ToList();
        }
        private void BindingData()
        {
            CBClass.ItemsSource = DBConnection.connect.Number.ToList();
            CBCharacter.ItemsSource = DBConnection.connect.Character.ToList();
        }
        private void lstvStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectStudent = lstvStudent.SelectedItem as Student;
            this.DataContext = selectStudent;
            CBCharacter.SelectedIndex = selectStudent.Class.Character.id;
            CBClass.SelectedIndex = selectStudent.Class.Number.id;
        }

        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text)
                || CBClass.SelectedIndex == -1 || CBCharacter.SelectedIndex == -1)
            {
                MessageBox.Show("пустые поля");
                return;
            }
            else
            {
                var selectClass = CBClass.SelectedItem as Number;
                var selectCharacter = CBCharacter.SelectedItem as Character;
                var getClass = DBMethodsFromStudent.GetClasses(selectClass.id, selectCharacter.id);
                var selectStudent = lstvStudent.SelectedItem as Student;
                DBMethodsFromStudent.EditStudent(selectStudent, txtName.Text, txtSurname.Text, txtPatronymic.Text, getClass.ID);
            }
        }
    }
}
