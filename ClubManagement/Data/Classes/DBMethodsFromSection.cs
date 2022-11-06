using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public static Section GetSection(int cabinet, int schedule, string title)
        {
            return GetSections().FirstOrDefault(s => s.CabinetID == cabinet && s.ScheduleID == schedule && s.Title == title);
        }
        public static Section GetSection(int cabinet, int schedule)
        {
            return GetSections().FirstOrDefault(s => s.CabinetID == cabinet && s.ScheduleID == schedule);
        }
        public static void AddImage(Section section, byte[] image)
        {
            var getSection = GetSection(section.CabinetID, section.ScheduleID, section.Title);
            if (getSection != null)
            {
                getSection.Image = image;
                DBConnection.connect.SaveChanges();
            }
        }
        public static ObservableCollection<StudentSection> GetStudentSections()
        {
            return new ObservableCollection<StudentSection>(DBConnection.connect.StudentSection);
        }
        public static IEnumerable<StudentSection> GetStudentSection(int cabinetID, int scheduleID)
        {
            return GetStudentSections().Where(s => s.Section.CabinetID == cabinetID && s.Section.ScheduleID == scheduleID).ToList();
        }
        public static bool MaxCount(Section section)
        {
            var getsectionStudentList = GetStudentSection(section.CabinetID, section.ScheduleID);
            var getMaxCount = GetSection(section.CabinetID, section.ScheduleID);
            if (getMaxCount.MaxCountOfVisitors <= getsectionStudentList.Where(s=>s.isActive==true).Count())
            {
                return true;
            }
            else
                return false;
        }
        public static void AddStudentInSection(Student student, Section section)
        {
            var getSection = DBMethodsFromSection.GetSection(section.CabinetID, section.ScheduleID);
            var getStudent = DBMethodsFromStudent.GetStudent(student);
            if (getStudent == null && getSection != null)
            {

            }
            else
            {
                MessageBox.Show("уже записан на данную секцию");
            }
        }
        public static void AddSection(string title, int cabinet, int maxCount, int schedule, bool isActive, byte[] image)
        {
            var getSectionTitle = GetSection(cabinet, schedule, title);
            var getSection = GetSection(cabinet, schedule);
            if (getSection == null && getSectionTitle == null)
            {
                Section section = new Section
                {
                    Title = title,
                    CabinetID = cabinet,
                    MaxCountOfVisitors = maxCount,
                    ScheduleID = schedule,
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
            var getSection = GetSection(oldsection.CabinetID, oldsection.ScheduleID, oldsection.Title);
            if (getSection != null)
            {
                DBConnection.connect.SaveChanges();
            }
        }
    }
}
