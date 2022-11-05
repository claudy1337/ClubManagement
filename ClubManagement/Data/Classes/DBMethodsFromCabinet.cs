using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClubManagement.Data.Classes;
using ClubManagement.Data.Model;

namespace ClubManagement.Data.Classes
{
    internal class DBMethodsFromCabinet
    {
        public static ObservableCollection<Cabinet> GetCabinets()
        {
            return new ObservableCollection<Cabinet>(DBConnection.connect.Cabinet);
        }
        public static IEnumerable<Cabinet> GetCabinet()
        {
            return GetCabinets().ToList();
        }
        public static IEnumerable<Cabinet> GetCabinet(string title)
        {
            return GetCabinets().Where(c => c.Title == title).ToList();
        }
        public static Cabinet GetCabinetTitle(string title)
        {
            return GetCabinets().FirstOrDefault(c => c.Title == title);
        }
        public static void AddCabinet(string title, bool state)
        {
            var getCabinet = GetCabinet(title);
            var getCabinetTitle = GetCabinetTitle(title);
            if (getCabinet == null || getCabinetTitle == null)
            {
                Cabinet cabinet = new Cabinet
                {
                    Title = title,
                    State = state
                };
                DBConnection.connect.Cabinet.Add(cabinet);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("добавлен");
            }
            else
            {
                MessageBox.Show("уже существует");
                return;
            }
        }
        public static void EditCabinet(Cabinet Oldcabinet, bool state)
        {
            var getCabinetTitle = GetCabinetTitle(Oldcabinet.Title);
            if (getCabinetTitle != null)
            {
                getCabinetTitle.State = state;
                DBConnection.connect.SaveChanges();
                MessageBox.Show("изменен");
            }

        }
    }
}
