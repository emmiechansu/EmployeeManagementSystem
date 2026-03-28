using EmployeeManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDataServices
{
    public interface IEmployeeDataService
    {
        void AddEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee? GetByName(string name);
    }
}