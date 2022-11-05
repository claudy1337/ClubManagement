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

namespace ClubManagement.Pages.AdminControl
{
    /// <summary>
    /// Логика взаимодействия для ControlTeacherPage.xaml
    /// </summary>
    public partial class ControlTeacherPage : Page
    {
        public static Teacher CurretTeacher;
        byte[] image;
        bool isActive = false;
        bool imgClick = false;
        public ControlTeacherPage(Teacher currnetTeacher)
        {
            CurretTeacher = currnetTeacher;
            InitializeComponent();
        }
    }
}
