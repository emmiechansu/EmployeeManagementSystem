using System;
using EmployeeManagementModels;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementDataService
{
    public class EmployeeDBData : IEmployeeDataService
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=EmployeeMgmtSys;Integrated Security=True;TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public EmployeeDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = GetEmployees();
            if (existing.Count == 0)
            {
                Add(new Employee { EmployeeId = "EMP001", Name = "MJ Pepito" });
                Add(new Employee { EmployeeId = "EMP002", Name = "Xavier Sales" });
            }
        }

        public string GenerateNextEmployeeId()
        {
            var employees = GetEmployees();
            if (employees.Count == 0)
                return "EMP001";

            var lastEmployee = employees.OrderByDescending(e => e.EmployeeId).First();
            int lastNumber = int.Parse(lastEmployee.EmployeeId.Substring(3));
            int nextNumber = lastNumber + 1;
            return "EMP" + nextNumber.ToString("000");
        }

        public void Add(Employee employee)
        {
            var insertStatement = "INSERT INTO Employees VALUES (@EmployeeId, @Name)";
            SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@Name", employee.Name);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Employee> GetEmployees()
        {
            var list = new List<Employee>();
            var cmd = new SqlCommand("SELECT EmployeeId, Name FROM Employees", sqlConnection);

            sqlConnection.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Employee
                {
                    EmployeeId = reader["EmployeeId"].ToString(),
                    Name = reader["Name"].ToString()
                });
            }

            sqlConnection.Close();
            return list;
        }

        public Employee GetById(string id)
        {
            var cmd = new SqlCommand("SELECT EmployeeId, Name FROM Employees WHERE EmployeeId=@id", sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();
            var reader = cmd.ExecuteReader();

            Employee emp = null;

            if (reader.Read())
            {
                emp = new Employee
                {
                    EmployeeId = reader["EmployeeId"].ToString(),
                    Name = reader["Name"].ToString()
                };
            }

            sqlConnection.Close();
            return emp;
        }

        public bool EmployeeIdExists(string employeeId)
        {
            var cmd = new SqlCommand("SELECT EmployeeId FROM Employees WHERE EmployeeId=@id", sqlConnection);
            cmd.Parameters.AddWithValue("@id", employeeId);

            sqlConnection.Open();
            var reader = cmd.ExecuteReader();
            bool exists = reader.Read();
            sqlConnection.Close();

            return exists;
        }

        public void Update(Employee employee)
        {
            var cmd = new SqlCommand("UPDATE Employees SET Name=@name WHERE EmployeeId=@id", sqlConnection);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@id", employee.EmployeeId);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(string employeeId)
        {
            var cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeId=@id", sqlConnection);
            cmd.Parameters.AddWithValue("@id", employeeId);

            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine($"Deleted {rowsAffected} employee(s) from database.");
        }

        public void AddAttendance(AttendanceRecord record)
        {
            Console.WriteLine("Attendance added to DB: " + record.Date);
        }

        public List<AttendanceRecord> GetAttendanceByEmployee(string employeeId) 
        {
            return new List<AttendanceRecord>();
        }

        public List<AttendanceRecord> GetAllAttendance() 
        {
            return new List<AttendanceRecord>(); 
        }
        
    }
}