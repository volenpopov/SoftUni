using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    [Table("Courses")]
    public class Course
    {
        public Course()
        {
            this.StudentsEnrolled = new List<StudentCourse>();
            this.Resources = new List<Resource>();
            this.HomeworkSubmissions = new List<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [Column(TypeName = "NVARCHAR(80)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "MONEY")]
        [Required]
        public decimal Price { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
