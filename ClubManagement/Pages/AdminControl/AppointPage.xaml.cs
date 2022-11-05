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
using ClubManagement.Data.Classes;
using ClubManagement.Data.Model;

namespace ClubManagement.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для AppointPage.xaml
    /// </summary>
    public partial class AppointPage : Page
    {
        public AppointPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            cbSection.ItemsSource = DBConnection.connect.Section.ToList();
            cbTeacher.ItemsSource = DBConnection.connect.Teacher.Where(t => t.isActive == true).ToList();
            lstvAppoint.ItemsSource = DBConnection.connect.Section_Teacher.ToList();
        }
        private void cbTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTeacher = cbTeacher.SelectedItem as Teacher;
            txtName.Text = $"{selectTeacher.User.Name}, {selectTeacher.User.Authorization.Login}";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbSection.SelectedIndex == -1 || cbTeacher.SelectedIndex == -1)
            {
                MessageBox.Show("заполните все поля");
            }
            else
            {
                var selectSection = cbSection.SelectedItem as Data.Model.Section;
                var selectTeacher = cbTeacher.SelectedItem as Teacher;
                DBMethodsFromSectionTeacher.AddTeacherFromSection(selectSection.ID, selectTeacher.ID);
            }
        }
    }
}
