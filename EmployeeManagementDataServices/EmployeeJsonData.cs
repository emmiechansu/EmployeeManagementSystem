using EmployeeManagementModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagementDataServices
{
    public class EmployeeJsonData
    {
        private List<Employee> accounts = new List<Employee>();
        private string _jsonFileName;

        public EmployeeJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Employee.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (accounts.Count <= 0)
            {
                accounts.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "MJ Pepito" });
                accounts.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "Charles Ynares" });
                accounts.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "Xavier Sales" });
                accounts.Add(new Employee { EmployeeID = Guid.NewGuid(), Name = "Matthew Fernandez" });

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Employee>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions { SkipValidation = true, Indented = true }),
                    accounts);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                accounts = JsonSerializer.Deserialize<List<Employee>>(
                    jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }
        public void AddEmployee(Employee emp)
        {
            accounts.Add(emp);
            SaveDataToJsonFile();
        }

        public List<Employee> GetAllEmployees()
        {
            return accounts;
        }
    }
}