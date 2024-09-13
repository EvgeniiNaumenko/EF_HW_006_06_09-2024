using HW_006_06_09_2024;
using Microsoft.EntityFrameworkCore;

class Program
{
    //Разработайте систему управления студентами и курсами для университета.В системе есть информация о студентах, 
    //    курсах, преподавателях и результате их обучения.

    //Определите следующие классы:
    //■ Student (Студент): Информация о студентах, включая их идентификатор, имя, фамилию и дату рождения.
    //■ Course (Курс): Информация о курсах, включая их идентификатор, название и описание.
    //■ Enrollment (Зачисление): Информация о зачислении студентов на курсы, включая идентификатор зачисления, 
    //идентификатор студента, идентификатор курса и дату зачисления.
    //■ Instructor (Преподаватель): Информация о преподавателях, включая их идентификатор, имя и фамилию.

    static void Main()
    {
        FillDataBase.Seed();
        using(ApplicationContext db =  new ApplicationContext())
        {
            //1) Получить список студентов, зачисленных на определенный курс.
            int courseId = 2;
            var studentListByCourse = db.Enrolments.Where(e => e.CourseId == courseId).Select(e => e.Student).ToList();
            //2) Получить список курсов, на которых учит определенный преподаватель.
            int instructorId = 1;
            var coursesByInstructor = db.Courses.Where(c => c.Instructors.Any(i=>i.Id == instructorId)).ToList();
            //3) Получить список курсов, на которых учит определенный преподаватель,
            //вместе с именами студентов, зачисленных на каждый курс.
            var coursesByInstructorAndStidents = db.Courses
                .Where(c => c.Instructors.Any(i=>i.Id == instructorId))
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .ToList();
            //4) Получить список курсов, на которые зачислено более 5 студентов.
            var CourseMore5Students = db.Courses
                .Where(c => c.Enrollments.Count() > 5)
                .ToList();
            //5) Получить список студентов, старше 25 лет.
            var studentsAolderThen25 = db.Students
                .Where(s => DateTime.Now.Year - s.DayOfBirth.Year > 25)
                .ToList();
            //6) Получить средний возраст всех студентов.
            var averageStudentsAge = db.Students
                .Average(s => DateTime.Now.Year - s.DayOfBirth.Year);
            //7) Получить самого молодого студента.
            var youngestStudent = db.Students
                .OrderBy(s => s.DayOfBirth)
                .FirstOrDefault();
            //8) Получить количество курсов, на которых учится студент с определенным Id.
            int studentId = 3;
            var curseCount = db.Enrolments
                .Count(c => c.StudentId == studentId);
            //9) Получить список имен всех студентов.
            var nameList = db.Students
                .Select(s=>s.Name)
                .ToList();
            //10) Сгруппировать студентов по возрасту.
            var groupStudentsByAge = db.Students
                .GroupBy(s => DateTime.Now.Year - s.DayOfBirth.Year)
            .ToList();
            //11) Получить список студентов, отсортированных по фамилии в алфавитном порядке.
            var sortedStudentList = db.Students
                .OrderBy(s => s.Surname)
                .ToList();
            //12) Получить список студентов вместе с информацией о зачислениях на курсы.
            var studentsAndInfo = db.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ToList();
            //13) Получить список студентов, не зачисленных на определенный курс.
            int course = 2;
            var studentsNotInCourse = db.Students
                .Where(s => !s.Enrollments.Any(e => e.CourseId == course))
                .ToList();
            //14) Получить список студентов, зачисленных одновременно на два определенных курса.
            int courseId1 = 1;
            int courseId2 = 2;
            var studentsWith2Course = db.Students
                 .Where(s => s.Enrollments.Any(e => e.CourseId == courseId1)
                         && s.Enrollments.Any(e => e.CourseId == courseId2))
                 .ToList();
            //15) Получить количество студентов на каждом курсе.
            var  studentsCountInCourse = db.Courses  
                .Select(c => new
                     {
                         Course = c,
                         StudentCount = c.Enrollments.Count
                     })
                    .ToList();
        }

    }
}