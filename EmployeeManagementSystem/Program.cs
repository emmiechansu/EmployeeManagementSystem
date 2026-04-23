using System;
using System.Collections.Generic;
using EmployeeManagementDataService;
using EmployeeManagementModels;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static EmployeeDBData dbData = new EmployeeDBData();
        static List<string> attendanceRecords = new List<string>();
        static int nextEmployeeId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
            EmployeeMenu();
        }

        static void EmployeeMenu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("\n----------");
                Console.WriteLine("EMPLOYEE MENU:");
                string[] options = new string[] {
                    "Add Employee",
                    "Time In",
                    "Time Out",
                    "View All Employees",
                    "Search Employee",
                    "Delete Employee",
                    "Display Logs"
                };
                ShowOptions(options);

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        TimeIn();
                        break;
                    case "3":
                        TimeOut();
                        break;
                    case "4":
                        ViewEmployees();
                        break;
                    case "5":
                        SearchEmployee();
                        break;
                    case "6":
                        DeleteEmployee();
                        break;
                    case "7":
                        DisplayLogs();
                        break;
                    default:
                        Console.WriteLine("Invalid.");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("ADDING EMPLOYEE:");

            string empId = dbData.GenerateNextEmployeeId();
            Console.WriteLine("ID: " + empId);

            Console.Write("Employee Name: ");
            string name = Console.ReadLine();

            if (name == null || name.Trim() == "")
            {
                Console.WriteLine("Name is required!");
                return;
            }

            Employee newEmp = new Employee
            {
                EmployeeId = empId,
                Name = name.Trim()
            };

            dbData.Add(newEmp);
            Console.WriteLine("Successfully added employee to DB:");
            Console.WriteLine("   ID: " + empId);
            Console.WriteLine("   Name: " + name.Trim());
        }

        static void ViewEmployees()
        {
            Console.WriteLine("\nLIST OF EMPLOYEES (FROM DB):");
            Console.WriteLine(new string('-', 35));

            var employees = dbData.GetEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found in database.");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine("ID: " + employees[i].EmployeeId + " | Name: " + employees[i].Name);
            }
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            string findEmp = Console.ReadLine();

            Employee emp = dbData.GetById(findEmp);
            if (emp != null)
            {
                Console.Write("New name [" + emp.Name + "]: ");
                string newName = Console.ReadLine();
                if (newName != null && newName.Trim() != "")
                {
                    emp.Name = newName.Trim();
                    dbData.Update(emp);
                    Console.WriteLine("Employee updated in DB!");
                }
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            string empId = Console.ReadLine();

            if (dbData.EmployeeIdExists(empId))
            {
                Console.WriteLine("Deleting from DB: " + dbData.GetById(empId).Name);
                Console.WriteLine("Employee marked for deletion!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static bool EmployeeExists(string empId)
        {
            return dbData.EmployeeIdExists(empId);
        }

        static void TimeIn()
        {
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();

            if (!EmployeeExists(empId))
            {
                Console.WriteLine("Employee ID not found! Cannot record time in.");
                return;
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            attendanceRecords.Add(empId + " TIME IN " + time);
            Console.WriteLine("Time IN recorded for employee ID: " + empId);
        }

        static void TimeOut()
        {
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();

            if (!EmployeeExists(empId))
            {
                Console.WriteLine("Employee ID not found! Cannot record time out.");
                return;
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            attendanceRecords.Add(empId + " TIME OUT " + time);
            Console.WriteLine("Time OUT recorded for employee ID: " + empId);
        }

        static void SearchEmployee()
        {
            Console.Write("Search (ID/Name): ");
            string search = Console.ReadLine();

            Console.WriteLine("\nFOUND (DB):");
            Console.WriteLine(new string('-', 30));
            bool foundAny = false;

            var employees = dbData.GetEmployees();
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmployeeId.ToLower().Contains(search.ToLower()) ||
                    employees[i].Name.ToLower().Contains(search.ToLower()))
                {
                    Console.WriteLine(employees[i].EmployeeId + " - " + employees[i].Name);
                    foundAny = true;
                }
            }

            if (!foundAny)
                Console.WriteLine("No employees found.");
        }

        static void DisplayLogs()
        {
            Console.WriteLine("\nATTENDANCE LOGS:");
            Console.WriteLine(new string('-', 50));
            if (attendanceRecords.Count == 0)
            {
                Console.WriteLine("No logs available.");
                return;
            }
            foreach (string log in attendanceRecords)
            {
                Console.WriteLine(log);
            }
        }

        static void ShowOptions(string[] options)
        {
            for (int x = 0; x < options.Length; x++)
            {
                Console.WriteLine("[" + (x + 1) + "] " + options[x]);
            }
            Console.Write("Enter the number of your option: ");
        }
    }
}