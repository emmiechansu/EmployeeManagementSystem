using System.Collections.Generic;
using System.Linq;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class EmployeeDataService
    {
        public static List<Employee> Employees = new List<Employee>();
        public static List<AttendanceRecord> AttendanceRecords = new List<AttendanceRecord>();

        public bool EmployeeIdExists(string employeeId)
        {
            return Employees.Any(emp => emp.EmployeeId == employeeId);
        }

        public void Add(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }

        public void Delete(string employeeId)
        {
            var emp = GetById(employeeId);
            if (emp != null)
                Employees.Remove(emp);
        }

        public void AddAttendance(AttendanceRecord record)
        {
            AttendanceRecords.Add(record);
        }

        public List<AttendanceRecord> GetAttendanceByEmployee(string employeeId)
        {
            return AttendanceRecords.Where(r => r.EmployeeId == employeeId).ToList();
        }

        public List<AttendanceRecord> GetAllAttendance()
        {
            return new List<AttendanceRecord>(AttendanceRecords);
        }

        public void Update(Employee employee)
        {
            var emp = GetById(employee.EmployeeId);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
            }
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(Employees);
        }

        public Employee GetById(string employeeId)
        {
            return Employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }
    }
}