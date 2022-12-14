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
    /// Логика взаимодействия для SectionsPage.xaml
    /// </summary>
    public partial class SectionsPage : Page
    {
        public static User CurrentUser;
        public SectionsPage(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }

        private void clTimeTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerSectionControl.Navigate(new TimeTablePage(CurrentUser));
        }

        private void clControlSection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fContainerSectionControl.Navigate(new SectionControl(CurrentUser));
        }
    }
}
