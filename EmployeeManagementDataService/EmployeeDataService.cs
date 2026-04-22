using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class EmployeeDataService
    {
        private EmployeeDBData dbData;

        public EmployeeDataService(EmployeeDBData dbData)
        {
            this.dbData = dbData;
        }

        public bool EmployeeIdExists(string employeeId)
        {
            return dbData.Employees.Any(e => e.EmployeeId == employeeId);
        }

        public void Add(Employee newEmployee)
        {
            dbData.Employees.Add(newEmployee);
        }

        public void AddAttendance(AttendanceRecord record)
        {
            dbData.AttendanceRecords.Add(record);
            
            var employee = GetById(record.EmployeeId); 
            if (employee != null)
            {
                employee.AttendanceRecords.Add(record);
            }
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.EmployeeId);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Department = employee.Department;
            }
        }

        public void Delete(string employeeId)
        {
            dbData.Employees.RemoveAll(e => e.EmployeeId == employeeId);
            dbData.AttendanceRecords.RemoveAll(r => r.EmployeeId == employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(dbData.Employees);
        }

        public Employee GetById(string employeeId)
        {
            return dbData.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public List<AttendanceRecord> GetAttendanceByEmployee(string employeeId)
        {
            return dbData.AttendanceRecords.Where(r => r.EmployeeId == employeeId).ToList();
        }

        public List<AttendanceRecord> GetAllAttendance()
        {
            return new List<AttendanceRecord>(dbData.AttendanceRecords);
        }
    }
}