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
        }

        private void cbSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAppoint_Click(object sender, RoutedEventArgs e)
        {
            var selectSection = cbSection.SelectedItem as Data.Model.Section;
            if (DBMethodsFromSection.MaxCount(selectSection) == true)
            {
                DBMethodsFromSection.add
            }
            else
            {
                MessageBox.Show("на данной секции макс кол участников");
            }
        }
    }
}
