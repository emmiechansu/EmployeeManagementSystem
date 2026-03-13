using EmployeeManagementAppService;
using EmployeeManagementDataService;
using EmployeeManagementModels;
using System;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("\n=== Employee Management System ===");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Record Attendance");
                Console.WriteLine("3. View Attendance");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Employee Name: ");
                        string empName = Console.ReadLine();
                        EmployeeAppService.AddEmployee(empName);
                        Console.WriteLine("Employee added!");
                        break;

                    case "2":
                        Console.Write("Employee Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Shift (1=Morning, 2=Afternoon): ");
                        string shift = Console.ReadLine();

                        Console.Write("Time In (e.g., 8AM, 1PM): ");
                        string timeIn = Console.ReadLine();

                        Console.Write("Time Out (e.g., 4PM, 6PM, 9PM, 11PM): ");
                        string timeOut = Console.ReadLine();

                        EmployeeAppService.RecordAttendance(name, shift, timeIn, timeOut);
                        Console.WriteLine("Attendance recorded!");
                        break;

                    case "3":
                        var logs = AttendanceDL.GetAllLogs();
                        if (logs.Count == 0)
                            Console.WriteLine("No records found.");
                        else
                            foreach (var log in logs)
                                Console.WriteLine($"{log.Name} | {log.Shift} | {log.Status} | OT: {log.Overtime} | UT: {log.Undertime}");
                        break;

                    case "4":
                        run = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}