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
using ClubManagement.Data.Classes;
using ClubManagement.Data.Model;
using System.Windows.Shapes;

namespace ClubManagement.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsPage()
        {
            InitializeComponent();
            DGSectionStudents.ItemsSource = DBConnection.connect.History.ToList();
            SetBindings();
        }

        private void DGSectionStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void SetBindings()
        {
            var list = GetSectionDictionary();
            var names = GetTopThreeSectionsName(list);
            tbFirst.Text = names[0];
            tbSecond.Text = names[1];
            tbThird.Text = names[2];
            //pbFirst.Value = list[0];
            //pbSecond.Value = list[1];
            //pbThird.Value = list[2];
        }
        private Dictionary<int, int> GetSectionDictionary()
        {
            var totalList = new Dictionary<int, int>();
            var sections = DBConnection.connect.Section.ToList();
            var studSections = DBConnection.connect.StudentSection.ToList();
            for (int i = 0; i < sections.Count; i++)
            {
                var tempStudList = studSections.Where(s => s.SectionID == sections[i].ID).ToList();
                if (tempStudList != null)
                {
                    totalList.Add(sections[i].ID, tempStudList.Count);
                }

            }

            var sortedDictionary = totalList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return sortedDictionary;
        }
        private List<string> GetTopThreeSectionsName(Dictionary<int, int> keyValuePairs)
        {
            var Sections = DBConnection.connect.Section.ToList();
            List<string> names = new List<string>();
            var threeNames = new List<string>();
            foreach (KeyValuePair<int, int> entry in keyValuePairs)
            {
                var tempName = Sections.Where(x => x.ID == entry.Key).FirstOrDefault();
                names.Add(tempName.Title);
            }


            return names;
        }
    }
}
