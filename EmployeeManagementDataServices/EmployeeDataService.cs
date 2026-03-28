using EmployeeManagementModels;
using System.Collections.Generic;

namespace EmployeeManagementDataServices
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private EmployeeJsonData _employeeData;

        public EmployeeDataService(EmployeeJsonData employeeData)
        {
            _employeeData = employeeData;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeData.GetAllEmployees();
        }

        public Employee? GetByName(string name)
        {
            return _employeeData.GetAllEmployees().FirstOrDefault(e => e.Name == name);
        }
    }
}