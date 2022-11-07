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
        List<Student> lstvSectionStudent = new List<Student>();
        public SectionControl(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            cbSection.ItemsSource = DBMethodsFromSectionTeacher.GetSection_Teachers(CurrentUser.ID);
            DGSectionStudents.ItemsSource = DBConnection.connect.StudentSection.ToList();
        }
        private void cbSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTeacher = cbSection.SelectedItem as Section_Teacher;
            DGSectionStudents.ItemsSource = DBConnection.connect.StudentSection.Where(s => s.SectionID == selectTeacher.Section.ID && s.isActive == true).ToList();
            CBTime.ItemsSource = DBConnection.connect.SectionSchedule.Where(s=>s.idSection == selectTeacher.Section.ID).ToList();
        }

        private void DGSectionStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = DGSectionStudents.SelectedItem as StudentSection;
            lstvSectionStudent.Add(select.Student);
            
        }

        private void btnMark_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lstvSectionStudent)
            {
                var getsectionChedule = cbSection.SelectedItem as Section_Teacher;
                DBMethodsFromHistory.AddHistory(getsectionChedule.Section, CurrentUser.ID, item.ID, DateTime.Now);
            }
            
           
            //for (int i = 0; i < 10; i += 2)
            //    (DGSectionStudents.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem).IsSelected = true;
        }

        private void Time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
