using System.Collections.Generic;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class EmployeeDBData
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }
}