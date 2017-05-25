using System.Collections.Generic;

namespace Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}