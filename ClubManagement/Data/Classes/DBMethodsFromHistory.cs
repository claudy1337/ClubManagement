using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Data.Model;
using ClubManagement.Data.Classes;

namespace ClubManagement.Data.Classes
{
    internal class DBMethodsFromHistory
    {
        public static ObservableCollection<History> GetHistories()
        {
            return new ObservableCollection<History>(DBConnection.connect.History);
        }
        public static void AddHistory(int sectionScheduleID, int teacherID, int studentID, DateTime date)
        {
            History history = new History
            {
                TeacherID = teacherID,
                StudentID = studentID,
                Date = date,
                SectionID = sectionScheduleID

            };
            DBConnection.connect.History.Add(history);
            DBConnection.connect.SaveChanges();
        }
    }
}
