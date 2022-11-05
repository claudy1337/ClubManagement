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
using ClubManagement.Pages;

namespace ClubManagement.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        bool selectActive;
        public TeacherPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            lstvTeacher.ItemsSource = DBConnection.connect.Teacher.ToList();
            cbTypeTeacher.ItemsSource = DBConnection.connect.TypeTeacher.ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            NavigationService.Navigate(new ControlTeacherPage(teacher));
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage());
        }

        private void lstvTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTeacher = lstvTeacher.SelectedItem as Teacher;
            NavigationService.Navigate(new ControlTeacherPage(selectTeacher));
        }

        private void cbTypeTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbActiveTeacher.SelectedIndex == 0)
                selectActive = false;
            else if (cbActiveTeacher.SelectedIndex == 1)
                selectActive = true;

            var selectType = cbTypeTeacher.SelectedItem as TypeTeacher;
            if (cbActiveTeacher.SelectedIndex == -1)
            {
                lstvTeacher.ItemsSource = DBConnection.connect.Teacher.Where(t => t.TypeTeacher.id == selectType.id).ToList();
            }
            else
            {
                lstvTeacher.ItemsSource = DBConnection.connect.Teacher.Where(t => t.TypeTeacher.id == selectType.id && t.isActive == selectActive).ToList();
            }
        }

        private void cbActiveTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbActiveTeacher.SelectedIndex == 0)
                selectActive = false;
            else if (cbActiveTeacher.SelectedIndex == 1)
                selectActive = true;
            var selectType = cbTypeTeacher.SelectedItem as TypeTeacher;
            if (cbTypeTeacher.SelectedIndex == -1)
            {
                lstvTeacher.ItemsSource = DBConnection.connect.Teacher.Where(t => t.isActive == selectActive).ToList();
            }
            else
            {
                lstvTeacher.ItemsSource = DBConnection.connect.Teacher.Where(t => t.TypeTeacher.id == selectType.id && t.isActive == selectActive).ToList();
            }
        }
    }
}
