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
    internal class DBMethodsFromShedule
    {
        public static ObservableCollection<Schedule> GetSchedules()
        {
            return new ObservableCollection<Schedule>(DBConnection.connect.Schedule);
        }
        public static Schedule GetSchedule(int hour, int minute, int day)
        {
            return GetSchedules().FirstOrDefault(s => s.idTimeMin == minute && s.idTimeHour == hour && s.DayOfWeekID == day);
        }
        public static Schedule GetSchedule(int cabinet, int hour, int minute, int day)
        {
            return GetSchedules().FirstOrDefault(s => s.idTimeMin == minute && s.idTimeHour == hour && s.DayOfWeekID == day);
        }
        public static void AddOrEditSchedule(int hour, int minute, int day)
        {
            var getSchedule = GetSchedule(hour, minute, day);
            if (getSchedule == null)
            {
                Schedule schedule = new Schedule
                {
                    DayOfWeekID = day,
                    idTimeHour = hour,
                    idTimeMin = minute
                };
                DBConnection.connect.Schedule.Add(schedule);
                DBConnection.connect.SaveChanges();
                MessageBox.Show("добавлен");
            }
            else
            {
                MessageBox.Show("время уже установлено");
            }
        }
    }
}
