using System.Collections.Generic;
using EmployeeManagementModels;
using EmployeeManagementDataService;

namespace EmployeeManagementAppService
{
    public class EmployeeAppService
    {
        EmployeeDataService employeeDataService = new EmployeeDataService(new EmployeeDBData());

       
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
            var todayRecords = employeeDataService.GetAttendanceByEmployee(employeeId)
                .Where(r => r.Date == DateTime.Now.ToString("yyyy-MM-dd") && string.IsNullOrEmpty(r.TimeOut))
                .FirstOrDefault();

            if (todayRecords == null)
                return false;

            todayRecords.TimeOut = DateTime.Now.ToString("HH:mm:ss");
          
            todayRecords.HoursWorked = 8.0; 

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