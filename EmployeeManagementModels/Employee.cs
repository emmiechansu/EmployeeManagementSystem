using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }  
        public string Name { get; set; }
    }

    public class Attendance
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Shift { get; set; }
        public string Status { get; set; }
        public string Overtime { get; set; }
        public string Undertime { get; set; }
    }
}