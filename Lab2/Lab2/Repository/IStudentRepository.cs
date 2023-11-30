using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Repository
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetAll(string limit, string offset, string sort, string minid, string maxid, string like, string globalike);
        Student GetStudent(int id);
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        void Save();
    }
}
