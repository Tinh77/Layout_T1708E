﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T1708ENewWeb.Models
{
    public class Student
    {
        [Key]
        public string RollNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Mark> Marks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public StudentStatus Status { get; set; }
        public Student()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StudentStatus.Activated;
        }
    }

    public enum StudentStatus
    {
        Activated = 0,
        Deactivated = 1
    }
}
