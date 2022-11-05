using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Data.Model;
using ClubManagement.Data.Classes;
using ClubManagement.Pages;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;

namespace ClubManagement.Data.Classes
{
    internal class DBMethodsFromStudent
    {
        public static ObservableCollection<Student> GetStudents()
        {
            return new ObservableCollection<Student>(DBConnection.connect.Student);
        }
        public static Student GetStudent(string name, string surname, string patronymic, int classId)
        {
            return GetStudents().FirstOrDefault(s=>s.Name == name && s.Patronymic == patronymic && s.Surname == surname && s.ClassID == classId);
        }
        public static ObservableCollection<Class> GetClasses()
        {
            return new ObservableCollection<Class>(DBConnection.connect.Class);
        }
        public static Class GetClasses(int idNumber, int idCharacter)
        {
            return GetClasses().FirstOrDefault(c=>c.NumberID == idNumber && c.СharacterID == idCharacter);
        }
        public static void AddStudent(int numberid, int characterid, string name, string surname, string patronymic, byte[] image)
        {
            var getClass = GetClasses(numberid, characterid);
            var getstudent  = GetStudent(name, surname, patronymic, getClass.ID);
            if (getstudent == null && getClass != null)
            {
                Student student = new Student
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Image = image,
                    ClassID = getClass.ID
                };
                DBConnection.connect.Student.Add(student);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("студент добавлен");
            }
            else
            {
                MessageBox.Show("студент уже существует или класс не собран");
            }
            
        }
    }
}
