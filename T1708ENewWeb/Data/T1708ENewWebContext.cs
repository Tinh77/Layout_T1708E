using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T1708ENewWeb.Models;

namespace T1708ENewWeb.Models
{
    public class T1708ENewWebContext : DbContext
    {
        public T1708ENewWebContext (DbContextOptions<T1708ENewWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                RollNumber = "A001",
                FirstName = "Giang",
                LastName = "Tinh",
                Email = "tinhgiang9898@gmail.com",
            },
            new Student()
            {
                RollNumber = "A002",
                FirstName = "Huong",
                LastName = "Ly",
                Email = "ly@gmail.com",
            },
            new Student()
            {
                RollNumber = "A003",
                FirstName = "Thanh",
                LastName = "Tung",
                Email = "thanhtung@gmail.com",
            });

            modelBuilder.Entity<Mark>().HasData(new Mark()
            {
                Id = 1,
                SubjectName = "Java",
                StudentRollNumber = "A001",
                SubjectMark = 20,
            },
           new Mark()
           {
               Id = 2,
               SubjectName = "C#",
               StudentRollNumber = "A002",
               SubjectMark = 20,
           },
           new Mark()
           {
               Id = 3,
               SubjectName = "PHP",
               StudentRollNumber = "A003",
               SubjectMark = 20,
           });
        }

        public DbSet<T1708ENewWeb.Models.Student> Student { get; set; }

        public DbSet<T1708ENewWeb.Models.Mark> Mark { get; set; }
    }
}
