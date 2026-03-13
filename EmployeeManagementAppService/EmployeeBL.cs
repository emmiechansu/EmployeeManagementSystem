using EmployeeManagementModels;
using EmployeeManagementDataService;

namespace EmployeeManagementAppService
{
    public class EmployeeBL
    {
        public EmployeeDL EmployeeDL
        {
            get => default;
            set
            {
            }
        }

        public static void AddEmployee(string name)
        {
            Employee emp = new Employee();
            emp.Name = name;

            EmployeeDL.AddEmployee(emp);
        }
    }
}