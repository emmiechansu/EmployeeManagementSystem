using EmployeeManagementDataServices;
using EmployeeManagementModels;
using System.Collections.Generic;

namespace EmployeeManagementAppService
{
    public class EmployeeAppService
    {
        EmployeeDataService employeeDataService = new EmployeeDataService(new EmployeeDBData());

        public void AddEmployee(string name)
        {
            var emp = new Employee { EmployeeID = Guid.NewGuid(), Name = name };
            employeeDataService.AddEmployee(emp);
        }

        public void RecordAttendance(string name, string shift, string timeIn, string timeOut)
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

            var att = new Attendance
            {
                EmployeeName = name,
                Shift = shiftName,
                Status = status,
                Overtime = overtime,
                Undertime = undertime
            };

            var attendanceData = new AttendanceDBData();
            attendanceData.AddLog(att);
        }

        public List<Employee> GetEmployees()
        {
            return employeeDataService.GetAllEmployees();
        }

        public Employee? GetEmployeeByName(string name)
        {
            return employeeDataService.GetByName(name);
        }

        public List<Attendance> GetAttendanceLogs()
        {
            var attendanceData = new AttendanceDBData();
            return attendanceData.GetAllLogs();
        }
    }
}