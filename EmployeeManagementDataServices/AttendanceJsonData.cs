using EmployeeManagementModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EmployeeManagementDataServices
{
    public class AttendanceJsonData
    {
        private List<Attendance> logs = new List<Attendance>();
        private string _jsonFileName;

        public AttendanceJsonData()
        {
            _jsonFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attendance.json");
            LoadLogs();
        }

        public void AddLog(Attendance log)
        {
            logs.Add(log);
            SaveLogs();
        }

        public List<Attendance> GetAllLogs()
        {
            return logs;
        }

        private void LoadLogs()
        {
            if (!File.Exists(_jsonFileName))
            {
                logs = new List<Attendance>();
                return;
            }

            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                logs = JsonSerializer.Deserialize<List<Attendance>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })?.ToList() ?? new List<Attendance>();
            }
        }

        private void SaveLogs()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize(new Utf8JsonWriter(outputStream, new JsonWriterOptions { SkipValidation = true, Indented = true }), logs);
            }
        }
    }
}