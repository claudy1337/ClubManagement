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

namespace ClubManagement.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        public TimetablePage()
        {
            InitializeComponent();
            BindingData();
        }

        private void btnAddTime_Click(object sender, RoutedEventArgs e)
        {
            if (CBDayOfWeek.SelectedIndex == -1 || CBHour.SelectedIndex == -1 || CBMinutes.SelectedIndex == -1)
            {
                MessageBox.Show("есть пустое значение");
                return;
            }
            else
            {
                var selectDay = CBDayOfWeek.SelectedItem as Data.Model.DayOfWeeks;
                var selectMin = CBMinutes.SelectedItem as Data.Model.TimeMinutes;
                var selectHour = CBHour.SelectedItem as Data.Model.TimeHour;
                DBMethodsFromShedule.AddOrEditSchedule(selectDay.ID, selectMin.id, selectHour.id);
                NavigationService.Navigate(new TimetablePage());
            }
        }
        private void BindingData()
        {
            lstvSchedule.ItemsSource = DBConnection.connect.Schedule.ToList();
            CBHour.ItemsSource = DBConnection.connect.TimeHour.ToList();
            CBMinutes.ItemsSource = DBConnection.connect.TimeMinutes.ToList();
            CBDayOfWeek.ItemsSource = DBConnection.connect.DayOfWeeks.ToList();
        }
    }
}
