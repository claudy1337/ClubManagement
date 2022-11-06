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

namespace ClubManagement.Pages.TeacherControl
{
    /// <summary>
    /// Логика взаимодействия для AppointPage.xaml
    /// </summary>
    public partial class AppointPage : Page
    {
        public static User User;
        public AppointPage(User user)
        {
            User = user;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            cbSection.ItemsSource = DBConnection.connect.Section.Where(s=>s.isActive == true).ToList();
            cbStudent.ItemsSource = DBConnection.connect.Student.ToList();
            
        }

        private void cbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectStudent = cbStudent.SelectedItem as Student;
            txtStudent.Text = $"{selectStudent.Name} {selectStudent.Class.Number.Numbers} {selectStudent.Class.Character.Сharacters}";
            if (cbSection.SelectedIndex == -1)
            {
                DGSectionStudents.ItemsSource = DBConnection.connect.StudentSection.Where(s => s.Student.ID == selectStudent.ID).ToList();
            }
            else
            {
                var selectSection = cbSection.SelectedItem as Data.Model.Section;
                DGSectionStudents.ItemsSource = DBConnection.connect.StudentSection.Where(s => s.SectionID == selectSection.ID && s.Student.ID == selectStudent.ID).ToList();
            }
        }

        private void cbSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectSection = cbSection.SelectedItem as Data.Model.Section;
            var getmaxCountInSection = DBMethodsFromSection.GetSection(selectSection.Cabinet.ID, selectSection.Schedule.ID);
            DGSectionStudents.ItemsSource = DBConnection.connect.StudentSection.Where(s => s.SectionID == selectSection.ID).ToList();
            txtMaxCount.Text = "Записанно: " + DBConnection.connect.StudentSection.Where(s=>s.Section.ID == selectSection.ID && s.isActive==true).ToList().Count().ToString();
            txtMaxCountSection.Text = "Всего мест: " + getmaxCountInSection.MaxCountOfVisitors;

        }

        private void btnAppoint_Click(object sender, RoutedEventArgs e)
        {
            var selectSection = cbSection.SelectedItem as Data.Model.Section;
            var selectStudent = cbStudent.SelectedItem as Student;
            if (DBMethodsFromSection.IsCorrespondMaxCount(selectSection) == true)
            {
                DBMethodsFromSectionStudent.AddStudentInSection(selectStudent, selectSection);
                NavigationService.Navigate(new AppointPage(User));
            }
            else
            {
                MessageBox.Show("на данной секции макс кол участников или студент записан");
            }
        }

        private void DGSectionStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AppointPage(User));
        }

        private void editStudents_Click(object sender, RoutedEventArgs e)
        {
            var selectStudentSection = DGSectionStudents.SelectedItem as StudentSection;
            if (DBMethodsFromSection.IsCorrespondMaxCount(selectStudentSection.Section) == true && selectStudentSection.isActive == false)
            {
                DBMethodsFromSectionStudent.ReestablishStudentSection(selectStudentSection);
                NavigationService.Navigate(new AppointPage(User));
            }
            else
            {
                MessageBox.Show("уже записан или на данной секции макс кол участников");
                return;
            }
        }
    }
}
