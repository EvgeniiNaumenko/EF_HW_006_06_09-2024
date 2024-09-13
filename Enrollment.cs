using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_006_06_09_2024
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }    

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrollmentDay { get; set; }
    }
}
