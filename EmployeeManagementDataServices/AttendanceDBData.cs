using EmployeeManagementModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace EmployeeManagementDataServices
{
    public class AttendanceDBData
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=EmployeeMgmtSys;Integrated Security=True;TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public AttendanceDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddLog(Attendance attendance)
        {
            var insertStatement = @"
                INSERT INTO Attendance (EmployeeID, EmployeeName, Shift, Status, Overtime, Undertime) 
                VALUES (@EmployeeID, @EmployeeName, @Shift, @Status, @Overtime, @Undertime)";

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
            {
                insertCommand.Parameters.AddWithValue("@EmployeeID", Guid.Empty); 
                insertCommand.Parameters.AddWithValue("@EmployeeName", attendance.EmployeeName);
                insertCommand.Parameters.AddWithValue("@Shift", attendance.Shift);
                insertCommand.Parameters.AddWithValue("@Status", attendance.Status);
                insertCommand.Parameters.AddWithValue("@Overtime", attendance.Overtime);
                insertCommand.Parameters.AddWithValue("@Undertime", attendance.Undertime);

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Attendance> GetAllLogs()
        {
            var selectStatement = "SELECT EmployeeID, EmployeeName, Shift, Status, Overtime, Undertime FROM Attendance";

            var logs = new List<Attendance>();

            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new Attendance
                        {
                            EmployeeID = Guid.Parse(reader["EmployeeID"].ToString()),
                            EmployeeName = reader["EmployeeName"].ToString(),
                            Shift = reader["Shift"].ToString(),
                            Status = reader["Status"].ToString(),
                            Overtime = reader["Overtime"].ToString(),
                            Undertime = reader["Undertime"].ToString()
                        });
                    }
                }
                sqlConnection.Close();
            }

            return logs;
        }
    }
}