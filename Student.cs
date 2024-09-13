using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_006_06_09_2024
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DayOfBirth { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
