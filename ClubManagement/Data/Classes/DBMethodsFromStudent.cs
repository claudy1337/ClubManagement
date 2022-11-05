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
        
        public static void AddStudent(string name, string surname, string patronymic, int classId, byte[] image)
        {
            var getstudent  = GetStudent(name, surname, patronymic, classId);
            if (getstudent == null)
            {
                Student student = new Student
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Image = image,
                    ClassID = classId
                };
                DBConnection.connect.Student.Add(student);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("студент добавлен");
            }
            else
            {
                MessageBox.Show("студент уже существует");
            }
            
        }
    }
}
