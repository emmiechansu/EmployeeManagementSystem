using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    internal class Program
    {
       
        static List<string> employeeIds = new List<string>();
        static List<string> employeeNames = new List<string>();
        static List<string> employeeDepts = new List<string>();
        static List<string> attendanceRecords = new List<string>();

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
                    "View My Records",
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
                        ViewMyRecords();
                        break;
                    case "5":
                        ViewEmployees();
                        break;
                    case "6":
                        SearchEmployee();
                        break;
                    case "7":
                        DeleteEmployee();
                        break;
                    case "8":
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
            bool valid = true;
            foreach (var empId in employeeIds)
            {
                if (empId == id)
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }

        static void AddEmployee()
        {
            Console.WriteLine("ADDING EMPLOYEE:");
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();

            if (!ValidateEmployeeId(empId))
            {
                Console.WriteLine("Employee ID already exists.");
                return;
            }

            Console.Write("Employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Department: ");
            string dept = Console.ReadLine();

           
            employeeIds.Add(empId);
            employeeNames.Add(name);
            employeeDepts.Add(dept);

            Console.WriteLine($"Successfully added employee {empId}");
        }

        static void ViewEmployees()
        {
            Console.WriteLine("\nLIST OF EMPLOYEES:");

            for (int i = 0; i < employeeIds.Count; i++)
            {
                Console.WriteLine($"ID: {employeeIds[i]} Name: {employeeNames[i]} Dept: {employeeDepts[i]}");
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
                    Console.Write("New name: ");
                    employeeNames[i] = Console.ReadLine();
                    Console.Write("New department: ");
                    employeeDepts[i] = Console.ReadLine();
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
                    employeeIds.RemoveAt(i);
                    employeeNames.RemoveAt(i);
                    employeeDepts.RemoveAt(i);
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
            attendanceRecords.Add($"{empId} TIME IN {time}");
            Console.WriteLine("✅ Time IN recorded!");
        }

        static void TimeOut()
        {
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            attendanceRecords.Add($"{empId} TIME OUT {time}");
            Console.WriteLine("✅ Time OUT recorded!");
        }

        static void ViewMyRecords()
        {
            Console.Write("Employee ID: ");
            string empId = Console.ReadLine();

            Console.WriteLine($"\nRECORDS FOR {empId}:");
            bool found = false;
            foreach (string record in attendanceRecords)
            {
                if (record.Contains(empId))
                {
                    Console.WriteLine(record);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("No records found.");
        }

        static void SearchEmployee()
        {
            Console.Write("Search (ID/Name): ");
            string search = Console.ReadLine().ToLower();

            Console.WriteLine("\nFOUND:");
            for (int i = 0; i < employeeIds.Count; i++)
            {
                if (employeeIds[i].ToLower().Contains(search) ||
                    employeeNames[i].ToLower().Contains(search))
                {
                    Console.WriteLine($"{employeeIds[i]} - {employeeNames[i]} - {employeeDepts[i]}");
                }
            }
        }

        static void DisplayLogs()
        {
            Console.WriteLine("\nATTENDANCE LOGS:");
            foreach (string log in attendanceRecords)
            {
                Console.WriteLine(log);
            }
        }

     
        static void ShowOptions(string[] options)
        {
            for (int x = 0; x < options.Length; x++)
            {
                Console.WriteLine($"[{x + 1}] {options[x]}");
            }
            Console.Write("Enter the number of your option: ");
        }
    }
}