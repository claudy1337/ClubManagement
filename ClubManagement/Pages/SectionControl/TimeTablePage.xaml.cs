using ClubManagement.Data.Model;
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

namespace ClubManagement.Pages.SectionControl
{
    /// <summary>
    /// Логика взаимодействия для TimeTablePage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        public static User CurrentUser;
        public TimeTablePage(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            DGTimeTable.ItemsSource = DBConnection.connect.Section_Teacher.Where(s=>s.Teacher.User.ID == CurrentUser.ID).ToList();
            cbSectionTeacher.ItemsSource = DBMethodsFromSectionTeacher.GetSection_Teachers(CurrentUser.ID);
        }
        private void cbSectionTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTeacher = cbSectionTeacher.SelectedItem as Section_Teacher;
            DGTimeTable.ItemsSource = DBConnection.connect.Section_Teacher.Where(s => s.idSection == selectTeacher.Section.ID && s.isActive == true && s.Teacher.idUser == CurrentUser.ID).ToList();
        }
        private void DGTimeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
