using System.Collections.Generic;
using System.Linq;
using LAB2.Models;
using LAB2.Data;

namespace LAB2.Logic
{
    public class StudentService
    {
        private readonly MongoRepository _repo = new MongoRepository();

        public List<Student> GetAll() => _repo.GetAll();

        public void Add(Student s) => _repo.Add(s);

        public void Update(Student s) => _repo.Update(s);

        public void Delete(int id) => _repo.Delete(id);

        public List<Student> Search(string kw)
        {
            var all = _repo.GetAll();
            return all.Where(s =>
                s.Id.ToString() == kw ||
                s.Name.ToLower().Contains(kw.ToLower()) ||
                s.Address.ToLower().Contains(kw.ToLower()) ||
                s.Grade.ToString() == kw
            ).ToList();
        }
    }
}