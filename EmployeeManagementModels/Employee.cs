using System;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }

    public class AttendanceRecord
    {
        public string Date { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Shift { get; set; }
        public string EmployeeId { get; set; }
        public double HoursWorked { get; set; }
    }
}