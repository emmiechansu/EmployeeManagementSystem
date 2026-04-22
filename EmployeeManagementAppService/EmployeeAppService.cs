using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementModels;
using EmployeeManagementDataService;

namespace EmployeeManagementAppService
{
    public class EmployeeAppService
    {
        private EmployeeDataService employeeDataService;

        public EmployeeAppService()
        {
            employeeDataService = new EmployeeDataService();
        }

        public bool Register(Employee newEmployee)
        {
            if (employeeDataService.EmployeeIdExists(newEmployee.EmployeeId))
                return false;

            employeeDataService.Add(newEmployee);
            return true;
        }

        public bool UpdateEmployee(Employee employee)
        {
            var existing = employeeDataService.GetById(employee.EmployeeId);
            if (existing == null)
                return false;

            employeeDataService.Update(employee);
            return true;
        }

        public bool DeleteEmployee(string employeeId)
        {
            if (!employeeDataService.EmployeeIdExists(employeeId))
                return false;

            employeeDataService.Delete(employeeId);
            return true;
        }

        public bool TimeIn(string employeeId, string shift)
        {
            var employee = employeeDataService.GetById(employeeId);
            if (employee == null)
                return false;

            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var timeIn = DateTime.Now.ToString("HH:mm:ss");

            var record = new AttendanceRecord
            {
                EmployeeId = employeeId,
                Date = today,
                TimeIn = timeIn,
                Shift = shift
            };

            employeeDataService.AddAttendance(record);
            return true;
        }

        public bool TimeOut(string employeeId)
        {
            var todayRecord = employeeDataService.GetAttendanceByEmployee(employeeId)
                .Where(r => r.Date == DateTime.Now.ToString("yyyy-MM-dd") && string.IsNullOrEmpty(r.TimeOut))
                .FirstOrDefault();

            if (todayRecord == null)
                return false;

            todayRecord.TimeOut = DateTime.Now.ToString("HH:mm:ss");
            todayRecord.HoursWorked = 8.0;

            return true;
        }

        public List<Employee> GetEmployees()
        {
            return employeeDataService.GetEmployees();
        }

        public Employee GetEmployee(string employeeId)
        {
            return employeeDataService.GetById(employeeId);
        }

        public List<AttendanceRecord> GetAttendanceRecords()
        {
            return employeeDataService.GetAllAttendance();
        }
    }
}