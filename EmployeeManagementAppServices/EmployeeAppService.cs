using EmployeeManagementDataServices;
using EmployeeManagementModels;

namespace EmployeeManagementAppService
{
    public class EmployeeAppService
    {
        public static void AddEmployee(string name)
        {
            Employee emp = new Employee { Name = name };
            EmployeeDL.AddEmployee(emp);
        }

        public static void RecordAttendance(string name, string shift, string timeIn, string timeOut)
        {
            string status = "On Time";
            string overtime = "No";
            string undertime = "No";
            string shiftName = "";

            if (shift == "1")
            {
                shiftName = "Morning";

                if (timeIn != "8AM")
                    status = "Late";

                if (timeOut == "6PM")
                    overtime = "Yes";

                if (timeOut == "4PM")
                    undertime = "Yes";
            }
            else if (shift == "2")
            {
                shiftName = "Afternoon";

                if (timeIn != "1PM")
                    status = "Late";

                if (timeOut == "11PM")
                    overtime = "Yes";

                if (timeOut == "9PM")
                    undertime = "Yes";
            }

            Attendance att = new Attendance
            {
                Name = name,
                Shift = shiftName,
                Status = status,
                Overtime = overtime,
                Undertime = undertime
            };

            AttendanceDL.AddLog(att);
        }
    }
}