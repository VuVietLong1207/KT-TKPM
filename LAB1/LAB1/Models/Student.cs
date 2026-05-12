using System;

namespace LAB1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public int Age { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name},{Email},{Address},{Age},{Grade}";
        }

        public static Student FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new Student
            {
                Id = int.Parse(values[0]),
                Name = values[1],
                Email = values[2],
                Address = values[3],
                Age = int.Parse(values[4]),
                Grade = double.Parse(values[5])
            };
        }
    }
}