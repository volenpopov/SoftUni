using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        { }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        { } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-MFJ6K8M\SQLEXPRESS;
                                              Database=StudentSystem;
                                              Trusted_Connection=True;");
            }                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasMany(s => s.CourseEnrollments)
                .WithOne(sc => sc.Student)
                .HasForeignKey(c => c.StudentId);
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasMany(s => s.HomeworkSubmissions)
                .WithOne(sc => sc.Student)
                .HasForeignKey(c => c.StudentId);
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasMany(c => c.Resources)
                .WithOne(cr => cr.Course)
                .HasForeignKey(cr => cr.CourseId);
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasMany(c => c.HomeworkSubmissions)
                .WithOne(ch => ch.Course)
                .HasForeignKey(ch => ch.CourseId);
            });

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}
