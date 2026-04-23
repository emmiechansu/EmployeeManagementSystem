using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class EmployeeInMemoryData : IEmployeeDataService
    {
        public static List<Employee> Employees = new List<Employee>();
        public static List<AttendanceRecord> AttendanceRecords = new List<AttendanceRecord>();

        public EmployeeInMemoryData()
        {
            Employees.Add(new Employee
            {
                EmployeeId = "EMP001",
                Name = "MJ Pepito",
            });

            Employees.Add(new Employee
            {
                EmployeeId = "EMP002",
                Name = "Xavier Sales",
            });

            Employees.Add(new Employee
            {
                EmployeeId = "EMP003",
                Name = "Mickey Abelidas",
            });

            AttendanceRecords.Add(new AttendanceRecord
            {
                Date = "2026-04-15",
                TimeIn = "09:00",
                TimeOut = "17:00",
                EmployeeId = "EMP001",
                HoursWorked = 8.0
            });
        }

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

        public void Update(Employee employee)
        {
            var emp = GetById(employee.EmployeeId);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
            }
        }

        public Employee GetById(string employeeId)
        {
            return Employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(Employees);
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
    }
}