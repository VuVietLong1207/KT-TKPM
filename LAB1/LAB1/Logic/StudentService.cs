using System.Collections.Generic;
using System.Linq;
using LAB1.Models; // Kết nối tới Models
using LAB1.Data;   // Kết nối tới Data

namespace LAB1.Logic
{
    public class StudentService
    {
        private readonly StudentRepository _repository = new StudentRepository();
        private List<Student> _students;

        public StudentService()
        {
            _students = _repository.GetData();
        }

        public List<Student> GetAll() => _students;

        public void Add(Student s)
        {
            _students.Add(s);
            _repository.SaveData(_students);
        }

        public bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return false;
            _students.Remove(student);
            _repository.SaveData(_students);
            return true;
        }

        public void Update(Student updatedStudent)
        {
            var index = _students.FindIndex(s => s.Id == updatedStudent.Id);
            if (index != -1)
            {
                _students[index] = updatedStudent;
                _repository.SaveData(_students);
            }
        }

        public List<Student> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return _students;

            return _students.Where(s =>
                s.Id.ToString() == keyword ||
                s.Name.ToLower().Contains(keyword.ToLower()) ||
                s.Address.ToLower().Contains(keyword.ToLower()) ||
                s.Grade.ToString() == keyword
            ).ToList();
        }
    }
}