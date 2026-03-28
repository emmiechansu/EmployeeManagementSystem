using EmployeeManagementModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace EmployeeManagementDataServices
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
            var existing = GetAllEmployees();

            if (existing.Count == 0)
            {
                AddEmployee(new Employee { EmployeeID = Guid.NewGuid(), Name = "MJ Pepito" });
                AddEmployee(new Employee { EmployeeID = Guid.NewGuid(), Name = "Charles Ynares" });
                AddEmployee(new Employee { EmployeeID = Guid.NewGuid(), Name = "Xavier Sales" });
                AddEmployee(new Employee { EmployeeID = Guid.NewGuid(), Name = "Matthew Fernandez" });
            }
        }

        public void AddEmployee(Employee employee)
        {
            var insertStatement = "INSERT INTO Employee (EmployeeID, Name) VALUES (@EmployeeID, @Name)";

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
            {
                insertCommand.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                insertCommand.Parameters.AddWithValue("@Name", employee.Name);

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var selectStatement = "SELECT EmployeeID, Name FROM Employee";

            var employees = new List<Employee>();

            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeID = Guid.Parse(reader["EmployeeID"].ToString()),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
                sqlConnection.Close();
            }

            return employees;
        }

        public Employee? GetByName(string name)
        {
            var selectStatement = "SELECT EmployeeID, Name FROM Employee WHERE Name = @Name";

            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                selectCommand.Parameters.AddWithValue("@Name", name);

                sqlConnection.Open();
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employee
                        {
                            EmployeeID = Guid.Parse(reader["EmployeeID"].ToString()),
                            Name = reader["Name"].ToString()
                        };
                    }
                }
                sqlConnection.Close();
            }

            return null;
        }
    }
}