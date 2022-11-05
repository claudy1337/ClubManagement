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
using ClubManagement.Pages;
using ClubManagement.Data.Classes;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace ClubManagement.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для ControlSectionPage.xaml
    /// </summary>
    public partial class ControlSectionPage : Page
    {
        public static Data.Model.Section Section;
        byte[] image;
        bool isCheck = false;
        public ControlSectionPage(Data.Model.Section section)
        {
            Section = section;
            InitializeComponent();
            if (Section.isActive == null || Section.MaxCountOfVisitors == null || Section.Title == null)
            {
                isNullBindingData();
            }
            else
            {
                BindingData();
            }
            cbCabinet.ItemsSource = DBConnection.connect.Cabinet.Where(c => c.State == true).ToList();
            CBDayOfWeeks.ItemsSource = DBConnection.connect.DayOfWeeks.ToList();
            CBTimeHour.ItemsSource = DBConnection.connect.TimeHour.ToList();
            CBTimeMin.ItemsSource = DBConnection.connect.TimeMinutes.ToList();
        }
        private void BindingData()
        {
            txtEditOrAdd.Text = "Редактировать Секцию";
            btnEditOrAdd.Content = "Редактировать";
            cbCabinet.SelectedIndex = Section.CabinetID;
            this.DataContext = Section;
            if (Section.isActive == true)
            {
                CBIsActice.IsChecked = true;
            }
        }
        private void isNullBindingData()
        {
            txtEditOrAdd.Text = "Добавить Секцию";
            btnEditOrAdd.Content = "Добавить";
            string imagePath = "/Resources/default_section.png/";
            imgSection.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        private void txtMaxCount_TextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
                Regex regex = new Regex("[^1-9]+");
                e.Handled = regex.IsMatch(e.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("0 is not count");
                return;
            }
        }

        private void CBIsActice_Checked(object sender, RoutedEventArgs e)
        {
            CBIsActice.IsChecked = true;
            isCheck = true;
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgSection.Source = bitmapImage;
                image = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void btnEditOrAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtEditOrAdd.Text) || string.IsNullOrWhiteSpace(txtMaxCount.Text))
            {
                MessageBox.Show("заполните все поля");
            }
            else
            {
                if (Section.isActive == null || Section.MaxCountOfVisitors == null || Section.Title == null)
                {
                    var selectCabinet = cbCabinet.SelectedItem as Cabinet;
                    var selectHour = CBTimeHour.SelectedItem as TimeHour;
                    var selectMin = CBTimeMin.SelectedItem as TimeMinutes;
                    var selectDay = CBDayOfWeeks.SelectedItem as DayOfWeeks;
                    var getsched = DBMethodsFromShedule.GetSchedule(selectHour.id, selectMin.id, selectDay.ID);
                    if (getsched != null)
                    {
                        DBMethodsFromSection.AddSection(txtTitle.Text, selectCabinet.ID, Convert.ToInt32(txtMaxCount.Text), getsched.ID, isCheck, image);
                    }
                    else
                    {
                        MessageBox.Show("время не согласовано");
                    }

                }
                else
                {
                    DBMethodsFromSection.AddImage(Section, image);
                }
            }
        }
    }
}
