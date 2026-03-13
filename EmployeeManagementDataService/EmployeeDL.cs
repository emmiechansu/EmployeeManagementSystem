using System.Collections.Generic;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class EmployeeDL
    {
        public static List<Employee> employees = new List<Employee>();

        public static void AddEmployee(Employee emp)
        {
            employees.Add(emp);
        }

        public static List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}