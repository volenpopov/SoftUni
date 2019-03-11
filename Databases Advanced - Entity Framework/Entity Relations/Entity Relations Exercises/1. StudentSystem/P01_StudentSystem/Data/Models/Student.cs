using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    [Table("Students")]
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new List<StudentCourse>();
            this.HomeworkSubmissions = new List<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Required]
        public string Name { get; set; }

        [StringLength(maximumLength: 10, MinimumLength = 10,
            ErrorMessage = "PhoneNumber must be exactly 10 characters!")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
