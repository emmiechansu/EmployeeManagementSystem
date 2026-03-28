using EmployeeManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDataServices
{
    public class EmployeeInMemoryData : IEmployeeDataService
    {
        public List<Employee> dummyEmployees = new List<Employee>();

        public EmployeeInMemoryData()
        {
          
            dummyEmployees.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "MJ Pepito" });
            dummyEmployees.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "Charles Ynares" });
            dummyEmployees.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "Xavier Sales" });
            dummyEmployees.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "Matthew Fernandez" });
        }

        public void AddEmployee(Employee employee)
        {
            dummyEmployees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return dummyEmployees;
        }

        public Employee? GetByName(string name)
        {
            return dummyEmployees.FirstOrDefault(e => e.Name == name);
        }
    }
}