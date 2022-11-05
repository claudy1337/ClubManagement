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
        }
    }
}
