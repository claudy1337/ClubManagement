using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Data.Model;

namespace ClubManagement.Data.Classes
{
    internal class DBConnection
    {
        public static schoolEntities connect = new schoolEntities();
    }
}
