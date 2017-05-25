using System;
using System.Collections.Generic;

namespace Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}