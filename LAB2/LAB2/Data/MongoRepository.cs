using System.Collections.Generic;
using System.IO;
using System.Linq;
using LAB2.Models;

namespace LAB2.Data
{
    public class MongoRepository
    {
        private readonly string _filePath = "students_lab2.txt";

        public List<Student> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<Student>();

            return File.ReadAllLines(_filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(line => {
                           var v = line.Split(',');
                           return new Student
                           {
                               Id = int.Parse(v[0]),
                               Name = v[1],
                               Email = v[2],
                               Address = v[3],
                               Age = int.Parse(v[4]),
                               Grade = double.Parse(v[5])
                           };
                       }).ToList();
        }

        public void Add(Student s)
        {
            var list = GetAll();
            list.Add(s);
            Save(list);
        }

        public void Update(Student s)
        {
            var list = GetAll();
            var index = list.FindIndex(x => x.Id == s.Id);
            if (index != -1)
            {
                list[index] = s;
                Save(list);
            }
        }

        public void Delete(int id)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Id == id);
            Save(list);
        }

        private void Save(List<Student> list)
        {
            var lines = list.Select(s => $"{s.Id},{s.Name},{s.Email},{s.Address},{s.Age},{s.Grade}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}