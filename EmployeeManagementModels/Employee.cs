using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public string Name { get; set; }

        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}