using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static string[] employeeNames = new string[5];

        static List<string> attendanceLogs = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");

            PopulateData();

            bool isRecord = RecordOption();

            if (isRecord)
            {
                RecordAttendance();
            }

            DisplayLogs();
        }

        static bool RecordOption()
        {
            Console.Write("\nTime in? Yes or No: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "yes")
                return true;
            else
                return false;
        }

        static void PopulateData()
        {
            employeeNames[0] = "Juan Dela Cruz";
            employeeNames[1] = "Maria Fabreag";
            employeeNames[2] = "Pedro Pascual";
            employeeNames[3] = "Glenn Cordial";
            employeeNames[4] = "Mickey Abelidas";
        }
        static void RecordAttendance()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            int index = FindEmployee(name);

            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine("\nSelect Shift:");
            Console.WriteLine("1 - Morning (8AM - 5PM)");
            Console.WriteLine("2 - Afternoon (1PM - 10PM)");
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
                            " | Shift: " + shift +
                            " | Status: " + status +
                            " | Overtime: " + overtime +
                            " | Undertime: " + undertime
                        );

            Console.WriteLine("Time In Successfully Recorded.");
        }
        static int FindEmployee(string name)
        {
            for (int i = 0; i < employeeNames.Length; i++)
            {
                if (employeeNames[i].ToLower() == name.ToLower())
                    return i;
            }

            return -1;
        }
        static void DisplayLogs()
        {
            Console.WriteLine("\nWorking Logs:");

            foreach (var log in attendanceLogs)
            {
                Console.WriteLine(log);
            }
        }
    }
}