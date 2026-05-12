using System.Collections.Generic;
using System.IO;
using System.Linq;
using LAB1.Models; // Quan trọng: Kết nối tới Models

namespace LAB1.Data
{
    public class StudentRepository
    {
        private readonly string _filePath = "students.txt";

        public List<Student> GetData()
        {
            if (!File.Exists(_filePath)) return new List<Student>();
            return File.ReadAllLines(_filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(Student.FromCsv)
                       .ToList();
        }

        public void SaveData(List<Student> students)
        {
            var lines = students.Select(s => s.ToString());
            File.WriteAllLines(_filePath, lines);
        }
    }
}