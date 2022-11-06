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
    /// Логика взаимодействия для SectionControl.xaml
    /// </summary>
    public partial class SectionControl : Page
    {
        public static User CurrentUser;
        public SectionControl(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }
    }
}
