using System.Collections.Generic;
using EmployeeManagementModels;

namespace EmployeeManagementDataService
{
    public class AttendanceDL
    {
        public static List<Attendance> logs = new List<Attendance>();

        public static void AddLog(Attendance att)
        {
            logs.Add(att);
        }

        public static List<Attendance> GetLogs()
        {
            return logs;
        }
    }
}