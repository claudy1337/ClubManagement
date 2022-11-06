using ClubManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClubManagement.Data.Classes
{
    internal class DBMethodsFromSectionStudent
    {
        public static void AddStudentInSection(Student student, Section section)
        {
            var getSection = DBMethodsFromSection.GetSection(section.CabinetID, section.ScheduleID);
            var getStudent = DBMethodsFromStudent.GetStudent(student);
            var getStudentSection = GetStudentSection(student, section);
            if (getStudent != null && getSection != null && getStudentSection == null)
            {
                StudentSection studentSection = new StudentSection
                {
                    isActive = true,
                    SectionID = section.ID,
                    StudentID = student.ID
                };
                DBConnection.connect.StudentSection.Add(studentSection);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("добавлен");
            }
            else
            {
                MessageBox.Show("уже записан на данную секцию");
            }
        }
        public static void ReestablishStudentSection(StudentSection studentSection)
        {
            studentSection.isActive = true;
            MessageBox.Show("студент восстановлен");
            DBConnection.connect.SaveChanges();
        }
        public static ObservableCollection<StudentSection> GetStudentSections()
        {
            return new ObservableCollection<StudentSection>(DBConnection.connect.StudentSection);
        }
        public static IEnumerable<StudentSection> GetStudentSection(int cabinetID, int scheduleID)
        {
            return GetStudentSections().Where(s => s.Section.CabinetID == cabinetID && s.Section.ScheduleID == scheduleID).ToList();
        }
        public static StudentSection GetStudentSection(Student student, Section section)
        {
            return GetStudentSections().FirstOrDefault(s => s.SectionID == section.ID && s.Student.ID == student.ID);
        }
    }
}
