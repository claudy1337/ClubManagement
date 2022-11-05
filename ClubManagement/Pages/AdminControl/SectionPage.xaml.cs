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

namespace ClubManagement.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для SectionPage.xaml
    /// </summary>
    public partial class SectionPage : Page
    {
        public SectionPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            lstvSection.ItemsSource = DBConnection.connect.Section.ToList();
        }
        private void lstvSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selelectSection = lstvSection.SelectedItem as Data.Model.Section;
            NavigationService.Navigate(new ControlSectionPage(selelectSection));
        }

        private void btnAddNewSection_Click(object sender, RoutedEventArgs e)
        {
            Data.Model.Section section = new Data.Model.Section();
            NavigationService.Navigate(new ControlSectionPage(section));
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SectionPage());
        }
    }
}
