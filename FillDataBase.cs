using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_006_06_09_2024
{
    public class FillDataBase
    {
        public static void Seed()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                
                var courses = new List<Course>
                {
                    new Course { Name = "Math", Description = "Basic Mathematics" },
                    new Course { Name = "Physics", Description = "Introduction to Physics" },
                    new Course { Name = "Computer Science", Description = "Programming Fundamentals" },
                    new Course { Name = "History", Description = "World History Overview" }
                };

                
                var students = new List<Student>
                {
                    new Student { Name = "John", Surname = "Doe", DayOfBirth = new DateTime(2000, 1, 15) },
                    new Student { Name = "Jane", Surname = "Smith", DayOfBirth = new DateTime(1999, 4, 23) },
                    new Student { Name = "Michael", Surname = "Johnson", DayOfBirth = new DateTime(1998, 8, 12) },
                    new Student { Name = "Emily", Surname = "Davis", DayOfBirth = new DateTime(2001, 2, 28) },
                    new Student { Name = "David", Surname = "Miller", DayOfBirth = new DateTime(2000, 5, 30) },
                    new Student { Name = "Sophia", Surname = "Wilson", DayOfBirth = new DateTime(1999, 7, 19) },
                    new Student { Name = "Daniel", Surname = "Moore", DayOfBirth = new DateTime(1998, 3, 22) },
                    new Student { Name = "Emma", Surname = "Taylor", DayOfBirth = new DateTime(2001, 6, 16) },
                    new Student { Name = "James", Surname = "Anderson", DayOfBirth = new DateTime(1999, 12, 5) },
                    new Student { Name = "Oliver", Surname = "Thomas", DayOfBirth = new DateTime(2000, 10, 11) },
                    new Student { Name = "Amelia", Surname = "Jackson", DayOfBirth = new DateTime(1998, 9, 25) },
                    new Student { Name = "Lucas", Surname = "White", DayOfBirth = new DateTime(2001, 11, 3) },
                    new Student { Name = "Ava", Surname = "Harris", DayOfBirth = new DateTime(1999, 5, 1) },
                    new Student { Name = "Elijah", Surname = "Martin", DayOfBirth = new DateTime(2000, 7, 13) },
                    new Student { Name = "Mia", Surname = "Thompson", DayOfBirth = new DateTime(2001, 4, 8) }
                };

                
                var instructors = new List<Instructor>
                {
                    new Instructor { Name = "Alice", Surname = "Brown" },
                    new Instructor { Name = "Bob", Surname = "Johnson" },
                    new Instructor { Name = "Charlie", Surname = "Lee" },
                    new Instructor { Name = "Diana", Surname = "Clark" },
                    new Instructor { Name = "Evan", Surname = "Lopez" },
                    new Instructor { Name = "Fiona", Surname = "Garcia" }
                };

                
                courses[0].Instructors.Add(instructors[0]); 
                courses[0].Instructors.Add(instructors[1]);
                courses[1].Instructors.Add(instructors[2]); 
                courses[1].Instructors.Add(instructors[3]);
                courses[2].Instructors.Add(instructors[4]); 
                courses[3].Instructors.Add(instructors[5]); 

                
                var enrollments = new List<Enrollment>
                {
                    new Enrollment { Student = students[0], Course = courses[0], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[1], Course = courses[0], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[2], Course = courses[1], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[3], Course = courses[1], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[4], Course = courses[2], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[5], Course = courses[2], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[6], Course = courses[3], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[7], Course = courses[3], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[8], Course = courses[0], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[9], Course = courses[1], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[10], Course = courses[2], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[11], Course = courses[3], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[12], Course = courses[0], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[13], Course = courses[1], EnrollmentDay = DateTime.Now },
                    new Enrollment { Student = students[14], Course = courses[2], EnrollmentDay = DateTime.Now }
                };

                
                db.Courses.AddRange(courses);
                db.Students.AddRange(students);
                db.Instructors.AddRange(instructors);
                db.Enrolments.AddRange(enrollments);

                
                db.SaveChanges();
            }
        }
    }
}
