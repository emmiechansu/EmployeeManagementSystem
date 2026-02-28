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
                RecordTimeIn();
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
        static void RecordTimeIn()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            int index = FindEmployee(name);

            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            attendanceLogs.Add(name + " | Time In Recorded");

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