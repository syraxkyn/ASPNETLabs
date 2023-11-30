using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentContext db;
        public StudentRepository()
        {
            this.db = new StudentContext();
        }
        public void Create(Student student)
        {
            db.Students.Add(student);
        }

        public void Delete(Student student)
        {
            db.Students.Remove(student);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll(string limit = null, string offset = null, string sort=null, string minid = null, string maxid = null, string like = null, string globalike = null)
        {
            string where = null;
            string top = null;
            if (offset == null && limit != null)
            {
                top = $"TOP {limit}";
                limit = null;
            }
            if (offset != null)
            {
                offset = $"OFFSET {offset} ROWS";
                if (limit != null)
                {
                    limit = $"FETCH NEXT {limit} ROWS ONLY";
                }
                else
                {
                    limit = $"FETCH NEXT 3 ROWS ONLY";
                }
            }
            if (sort != null)
            {
                sort = $"ORDER BY NAME {sort}";
            }
            else
            {
                sort = "ORDER BY ID";
            }
            if (minid != null || maxid != null || like != null)
            {
                if (globalike != null)
                {
                    like = null;
                    string[] words = globalike.Split(',');
                    globalike = $"AND Id Like '{words[0]}' AND Name Like '{words[1]}' And Phone Like'{words[2]}'";
                }
                if (like != null)
                {
                    like = $"AND Name Like '{like}'";
                }
                if (minid != null && maxid != null)
                {
                    where = $"WHERE Id > {minid} AND Id < {maxid} {like}";
                }
                if (minid != null && maxid == null)
                {
                    where = $"WHERE Id > {minid} {like}";
                }
                if (minid == null && maxid != null)
                {
                    where = $"WHERE Id < {maxid} {like}";
                }
                if (minid == null && maxid == null && like != null)
                {
                    like = like.Substring(4);
                    where = $"WHERE {like}";
                }
                if (minid == null && maxid == null && globalike != null)
                {
                    globalike = globalike.Substring(4);
                    where = $"WHERE {globalike}";
                }
            }
            else
            {
                if (globalike != null)
                {
                    string[] words = globalike.Split(',');
                    where = $"WHERE Id Like '{words[0]}' AND Name Like '{words[1]}' And Phone Like'{words[2]}'";
                }
            }
            var studentList = db.Students.SqlQuery(
                $"SELECT {top} * FROM STUDENTS" +
                $" {where}" +
                $" {sort}" +
                $" {offset}" +
                $" {limit}");
            return studentList;
        }

        public Student GetStudent(int id)
        {
            return db.Students.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
        }
    }
}