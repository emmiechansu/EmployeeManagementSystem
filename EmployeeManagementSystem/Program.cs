using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static List<string> employeeIds = new List<string>();
        static List<string> employeeNames = new List<string>();
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

        static bool ValidateEmployeeId(string id)
        {
            foreach (var empId in employeeIds)
            {
                if (empId == id)
                    return false;
            }
            return true;
        }

        static void AddEmployee()
        {
            Console.WriteLine("ADDING EMPLOYEE:");
            Console.WriteLine("ID: EMP" + nextEmployeeId.ToString("000"));

            Console.Write("Employee Name: ");
            string name = Console.ReadLine();

            if (name == null || name.Trim() == "")
            {
                Console.WriteLine("Name is required!");
                return;
            }

            string empId = "EMP" + nextEmployeeId.ToString("000");
            employeeIds.Add(empId);
            employeeNames.Add(name.Trim());

            Console.WriteLine("Successfully added employee:");
            Console.WriteLine("   ID: " + empId);
            Console.WriteLine("   Name: " + name.Trim());

            nextEmployeeId++;
        }

        static void ViewEmployees()
        {
            Console.WriteLine("\nLIST OF EMPLOYEES:");
            Console.WriteLine(new string('-', 35));

            if (employeeIds.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            for (int i = 0; i < employeeIds.Count; i++)
            {
                Console.WriteLine("ID: " + employeeIds[i] + " | Name: " + employeeNames[i]);
            }
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            string findEmp = Console.ReadLine();

            for (int i = 0; i < employeeIds.Count; i++)
            {
                if (employeeIds[i] == findEmp)
                {
                    Console.Write("New name [" + employeeNames[i] + "]: ");
                    string newName = Console.ReadLine();
                    if (newName != null && newName.Trim() != "")
                        employeeNames[i] = newName.Trim();

                    Console.WriteLine("Employee updated!");
                    return;
                }
            }
            Console.WriteLine("Employee not found.");
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            string empId = Console.ReadLine();

            for (int i = 0; i < employeeIds.Count; i++)
            {
                if (employeeIds[i] == empId)
                {
                    Console.WriteLine("Deleting: " + employeeNames[i]);
                    employeeIds.RemoveAt(i);
                    employeeNames.RemoveAt(i);
                    Console.WriteLine("Employee deleted!");
                    return;
                }
            }
            Console.WriteLine("Employee not found.");
        }

        static void TimeIn()
        {
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            attendanceRecords.Add(empId + " TIME IN " + time);
            Console.WriteLine("Time IN recorded!");
        }

        static void TimeOut()
        {
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            attendanceRecords.Add(empId + " TIME OUT " + time);
            Console.WriteLine("Time OUT recorded!");
        }

        static void SearchEmployee()
        {
            Console.Write("Search (ID/Name): ");
            string search = Console.ReadLine();

            Console.WriteLine("\nFOUND:");
            Console.WriteLine(new string('-', 30));
            bool foundAny = false;

            for (int i = 0; i < employeeIds.Count; i++)
            {
                if (employeeIds[i].ToLower().Contains(search.ToLower()) ||
                    employeeNames[i].ToLower().Contains(search.ToLower()))
                {
                    Console.WriteLine(employeeIds[i] + " - " + employeeNames[i]);
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