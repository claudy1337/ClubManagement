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
using System.IO;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace ClubManagement.Pages.TeacherControl
{
    /// <summary>
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        byte[] image;
        public AddStudentPage()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            CBClass.ItemsSource = DBConnection.connect.Class.ToList();
            CBCharacter.ItemsSource = DBConnection.connect.Class.ToList();
        }

        private void imgStudent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgStudent.Source = bitmapImage;
                image = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (CBClass.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtName.Text) 
            || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtPatronymic.Text))
            {
                MessageBox.Show("пустые значения");
                return;
            }
            else
            {
                DBMethodsFromStudent.AddStudent(txtName.Text, txtSurname.Text, txtPatronymic.Text,2 ,image);
            }
        }
    }
}
