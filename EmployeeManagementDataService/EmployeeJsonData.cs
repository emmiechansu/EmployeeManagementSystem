using EmployeeManagementModels;
using System.Text.Json;

namespace EmployeeManagementDataService
{
    public class EmployeeJsonData : IEmployeeDataService
    {
        private List<Employee> employees = new List<Employee>();
        private List<AttendanceRecord> attendanceRecords = new List<AttendanceRecord>();
        private string _jsonFileName;

        public EmployeeJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Employees.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (employees.Count <= 0)
            {
                employees.Add(new Employee { EmployeeId = "EMP001", Name = "MJ Pepito" });
                employees.Add(new Employee { EmployeeId = "EMP002", Name = "Xavier Sales" });
                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Employee>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true }), employees);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            if (File.Exists(_jsonFileName))
            {
                using (var jsonFileReader = File.OpenText(_jsonFileName))
                {
                    employees = JsonSerializer.Deserialize<List<Employee>>(
                        jsonFileReader.ReadToEnd(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                        .ToList();
                }
            }
        }

        public bool EmployeeIdExists(string employeeId)
        {
            RetrieveDataFromJsonFile();
            return employees.Any(x => x.EmployeeId == employeeId);
        }

        public void Add(Employee newEmployee)
        {
            RetrieveDataFromJsonFile();
            employees.Add(newEmployee);
            SaveDataToJsonFile();
        }

        public void Delete(string employeeId)
        {
            RetrieveDataFromJsonFile();
            var emp = GetById(employeeId);
            if (emp != null)
                employees.Remove(emp);
            SaveDataToJsonFile();
        }

        public void Update(Employee employee)
        {
            RetrieveDataFromJsonFile();
            var existing = employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Department = employee.Department;
            }
            SaveDataToJsonFile();
        }

        public Employee GetById(string employeeId)
        {
            RetrieveDataFromJsonFile();
            return employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public List<Employee> GetEmployees()
        {
            RetrieveDataFromJsonFile();
            return new List<Employee>(employees);
        }

        public void AddAttendance(AttendanceRecord record)
        {
            attendanceRecords.Add(record);
        }

        public List<AttendanceRecord> GetAttendanceByEmployee(string employeeId)
        {
            return attendanceRecords.Where(r => r.EmployeeId == employeeId).ToList();
        }

        public List<AttendanceRecord> GetAllAttendance()
        {
            return new List<AttendanceRecord>(attendanceRecords);
        }
    }
}