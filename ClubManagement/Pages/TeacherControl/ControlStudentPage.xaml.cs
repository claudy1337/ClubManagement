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
    /// Логика взаимодействия для ControlStudentPage.xaml
    /// </summary>
    public partial class ControlStudentPage : Page
    {
        public static User CurrentUser;
        public ControlStudentPage(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            cbSectionTeacher.ItemsSource = DBMethodsFromSectionTeacher.GetSection_Teachers(CurrentUser.ID);
        }

        private void cbSectionTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTeacher = cbSectionTeacher.SelectedItem as Section_Teacher;
            DGSectionStudents.ItemsSource = DBConnection.connect.StudentSection.Where(s=>s.SectionID == selectTeacher.Section.ID).ToList();
        }

        private void DGSectionStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnDeleteSectionInStudent_Click(object sender, RoutedEventArgs e)
        {
           try
           {
                if (DGSectionStudents.SelectedIndex == -1)
                {
                    MessageBox.Show("студент не выбран");
                    return;
                }
                else
                {
                    var selectStudent = DGSectionStudents.SelectedItem as StudentSection;
                    selectStudent.isActive = false;
                    DBConnection.connect.SaveChanges();
                }
                
            }
           catch(NullReferenceException)
           {
                MessageBox.Show("студент не выбран");
                return;
           }
        }
    }
}
