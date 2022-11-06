using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using ClubManagement.Data.Model;

namespace ClubManagement.Data.Classes
{
    internal class DBMethodsFromSection
    {
        public static Section CurrentSection;
        public static ObservableCollection<Section> GetSections()
        {
            return new ObservableCollection<Section>(DBConnection.connect.Section);
        }
        public static Section GetSection(int cabinet, string title)
        {
            return GetSections().FirstOrDefault(s => s.CabinetID == cabinet && s.Title == title);
        }
        public static Section GetSection(int cabinet)
        {
            return GetSections().FirstOrDefault(s => s.CabinetID == cabinet);
        }
        public static void AddImage(Section section, byte[] image)
        {
            var getSection = GetSection(section.CabinetID, section.Title);
            if (getSection != null)
            {
                getSection.Image = image;
                DBConnection.connect.SaveChanges();
            }
        }
        
        public static bool IsCorrespondMaxCount(Section section)
        {
            var getsectionStudentList = DBMethodsFromSectionStudent.GetStudentSection(section.CabinetID);
            var getMaxCount = GetSection(section.CabinetID);
            if (getMaxCount.MaxCountOfVisitors > getsectionStudentList.Where(s => s.isActive == true).Count())
            {
                return true;
            }
            else
                return false;
        }
        public static ObservableCollection<SectionSchedule> GetSectionSchedules()
        {
            return new ObservableCollection<SectionSchedule>(DBConnection.connect.SectionSchedule);
        }
        public static SectionSchedule GetSectionSchedule(int idSection, int idSchedule)
        {
            return GetSectionSchedules().FirstOrDefault(s=>s.idSchedule == idSchedule && s.idSection == idSection);
        }
        public static void AddSectionSchedule(int section, int schedule)
        {
            var getsectionSchedule = GetSectionSchedule(section, schedule);
            if (getsectionSchedule == null)
            {
                SectionSchedule sectionSchedule = new SectionSchedule
                {
                    idSchedule = schedule,
                    idSection = section
                };
                DBConnection.connect.SectionSchedule.Add(sectionSchedule);
                DBConnection.connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("данная секция уже записанна на это время");
                return;
            }
           
        }
        public static void AddSection(string title, int cabinet, int maxCount, int schedule, bool isActive, byte[] image)
        {
            var getSectionTitle = GetSection(cabinet, title);
            var getSection = GetSection(cabinet);
            if (getSection == null && getSectionTitle == null)
            {
                Section section = new Section
                {
                    Title = title,
                    CabinetID = cabinet,
                    MaxCountOfVisitors = maxCount,
                    isActive = isActive,
                    Image = image
                };
                CurrentSection = section;
                DBConnection.connect.Section.Add(section);
                DBConnection.connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("такая секция уже есть");
                return;
            }
        }
        public static void EditSection(Section oldsection)
        {
            var getSection = GetSection(oldsection.CabinetID, oldsection.Title);
            if (getSection != null)
            {
                DBConnection.connect.SaveChanges();
            }
        }
    }
}
