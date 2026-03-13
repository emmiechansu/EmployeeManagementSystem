
using System.Collections.Generic;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public static class EmployeeDL
    {
        public static List<Employee> Employees = new List<Employee>();

        public static void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
        }

        public static List<Employee> GetAllEmployees()
        {
            return Employees;
        }
    }

    public static class AttendanceDL
    {
        public static List<Attendance> Attendances = new List<Attendance>();

        public static void AddLog(Attendance att)
        {
            Attendances.Add(att);
        }

        public static List<Attendance> GetAllLogs()
        {
            return Attendances;
        }
    }
}