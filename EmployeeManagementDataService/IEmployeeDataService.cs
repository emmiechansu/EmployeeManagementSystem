using EmployeeManagementModels;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDataService
{
    public interface IEmployeeDataService
    {
        bool EmployeeIdExists(string employeeId);
        void Add(Employee newEmployee);
        void Delete(string employeeId);
        void Update(Employee employee);
        Employee GetById(string employeeId);
        List<Employee> GetEmployees();

        void AddAttendance(AttendanceRecord record);
        List<AttendanceRecord> GetAttendanceByEmployee(string employeeId);
        List<AttendanceRecord> GetAllAttendance();
    }
}