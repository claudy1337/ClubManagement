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
using ClubManagement.Pages.AdminControl;

namespace ClubManagement.Pages
{
    /// <summary>
    /// Логика взаимодействия для ControlPage.xaml
    /// </summary>
    public partial class ControlPage : Page
    {
        public static User CurrentUser;
        public ControlPage(User curentUser)
        {
            CurrentUser = curentUser;
            InitializeComponent();
            fContainerControl.Navigate(new SectionPage());
        }

        private void clSections_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerControl.Navigate(new SectionPage());
        }

        private void clTeacher_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerControl.Navigate(new TeacherPage());
        }

        private void clCabinet_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerControl.Navigate(new CabinetPage());
        }

        private void clTimeTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerControl.Navigate(new TimetablePage());
        }

        private void clAppoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerControl.Navigate(new AppointPage());
        }
    }
}
