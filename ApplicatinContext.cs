using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_006_06_09_2024
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrolments { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-C317JNM;Database=HWStudents;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors)
                .WithMany(c => c.Courses)
                .UsingEntity(c => c.ToTable("CourseInstructor");
        }
    }
}
