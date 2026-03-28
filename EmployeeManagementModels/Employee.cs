using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public string Name { get; set; } 
    }

    public class Attendance
    {
        public string Name { get; set; } 
        public string Shift { get; set; } 
        public string Status { get; set; } 
        public string Overtime { get; set; }
        public string Undertime { get; set; }
    }
}