using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Data.Model;
using ClubManagement.Data.Classes;
using System.Collections.ObjectModel;

namespace ClubManagement.Data.Classes
{
    internal class TopsClass
    {
        public static ObservableCollection<StudentSection> GetStudentSections()
        {
            return new ObservableCollection<StudentSection>(DBConnection.connect.StudentSection);
        }
    }
}
