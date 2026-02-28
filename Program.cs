using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    internal class Program
    {

        static string[] employeeNames = new string[5];
        static int employeeCount = 3;


        static List<string> attendanceLogs = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");


            PopulateData();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nSelect:");
                Console.WriteLine("[1] Add Employee");
                Console.WriteLine("[2] Time In/Time Out");
                Console.WriteLine("[3] View Records (Includes: Late, Undertime)");
                Console.WriteLine("[4] Shifting Schedule");
                Console.WriteLine("[5] Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        RecordAttendance();
                        break;
                    case "3":
                        DisplayLogs();
                        break;
                    case "4":
                        ShowShifts();
                        break;
                    case "5":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        static void AddEmployee()
        {
            if (employeeCount >= employeeNames.Length)
            {
                Console.WriteLine("Employee list is full.");
                return;
            }

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            employeeNames[employeeCount] = name;
            employeeCount++;

            Console.WriteLine("Employee Added Successfully!");
        }
        static void RecordAttendance()
        {
            if (employeeCount == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            if (FindEmployee(name) == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine("\nSelect Shift:");
            Console.WriteLine("[1] Morning (8AM-5PM)");
            Console.WriteLine("[2] Afternoon (1PM-10PM)");

            string shift = Console.ReadLine();

            Console.Write("Enter Time In: ");
            string timeIn = Console.ReadLine();

            Console.Write("Enter Time Out: ");
            string timeOut = Console.ReadLine();

            string status = "On Time";
            string overtime = "No";
            string undertime = "No";

            if (shift == "1")
            {
                if (timeIn != "8AM")
                    status = "Late";

                if (timeOut == "6PM")
                    overtime = "Yes";

                if (timeOut == "4PM")
                    undertime = "Yes";
            }

            else if (shift == "2")
            {
                if (timeIn != "1PM")
                    status = "Late";

                if (timeOut == "11PM")
                    overtime = "Yes";

                if (timeOut == "9PM")
                    undertime = "Yes";
            }

            attendanceLogs.Add(
                name +
                " | Shift: " + (shift == "1" ? "Morning" : "Afternoon") +
                " | Status: " + status +
                " | Overtime: " + overtime +
                " | Undertime: " + undertime
            );

            Console.WriteLine("Attendance Recorded Successfully.");
        }
        static int FindEmployee(string name)
        {
            for (int i = 0; i < employeeCount; i++)
            {
                if (employeeNames[i].ToLower() == name.ToLower())
                    return i;
            }
            return -1;
        }
        static void DisplayLogs()
        {
            if (attendanceLogs.Count == 0)
            {
                Console.WriteLine("No attendance records yet.");
                return;
            }

            Console.WriteLine("\nAttendance Records:");
            foreach (var log in attendanceLogs)
            {
                Console.WriteLine(log);
            }
        }
        static void ShowShifts()
        {
            Console.WriteLine("\nShift Schedule:");
            Console.WriteLine("Morning: 8AM - 5PM");
            Console.WriteLine("Afternoon: 1PM - 10PM");
        }


        static void PopulateData()
        {
            employeeNames[0] = "Juan Dela Cruz";
            employeeNames[1] = "Maria Fabreag";
            employeeNames[2] = "Pedro Pascual";
        }
    }
}
