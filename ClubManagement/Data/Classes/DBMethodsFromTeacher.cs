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
    internal class DBMethodsFromTeacher
    {
        public static Teacher CurrentTeacher;
        public static ObservableCollection<Teacher> GetTeachers()
        {
            return new ObservableCollection<Teacher>(DBConnection.connect.Teacher);
        }
        public static Teacher GetTeacher(string login, string password)
        {
            return GetTeachers().FirstOrDefault(t => t.User.Authorization.Login == login && t.User.Authorization.Password == password);
        }
        public static void AddTeacher(int typeTeacher, bool isActive)
        {
            var getAdmin = DBMethodsFromUser.GetAdminRole(DBMethodsFromUser.CurrentUser.Authorization.Login);
            if (DBMethodsFromUser.CurrentUser != null && getAdmin == false)
            {
                Teacher teacher = new Teacher
                {
                    idUser = DBMethodsFromUser.CurrentUser.ID,
                    idTypeTeacher = typeTeacher,
                    isActive = isActive
                };
                CurrentTeacher = teacher;
                MessageBox.Show("учитель добавлен");
                DBConnection.connect.Teacher.Add(teacher);
                DBConnection.connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("данные уже существуют");
                return;
            }
        }
        public static void EditTeacher(Teacher Oldteacher, int typeTeacher, bool isActive)
        {
            var getTeacher = GetTeacher(Oldteacher.User.Authorization.Login, Oldteacher.User.Authorization.Password);
            if (getTeacher != null)
            {
                getTeacher.idTypeTeacher = typeTeacher;
                getTeacher.isActive = isActive;
                DBConnection.connect.SaveChanges();
            }

        }
    }
}
