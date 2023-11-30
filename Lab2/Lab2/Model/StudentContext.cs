using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.Model
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("DefaultConnection")
        { }
        public DbSet<Student> Students { get; set; }
    }
}