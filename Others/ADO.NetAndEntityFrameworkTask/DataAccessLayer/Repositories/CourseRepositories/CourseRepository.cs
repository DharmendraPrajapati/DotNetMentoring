using System.Collections.Generic;
using System.Data.Entity;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.CourseRepositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Course> GetTopEnrolledCourses(IEnumerable<Course> courses)
        {
            var allCoruses = new List<Course>();
            foreach(var course in courses)
            {
                allCoruses.Add(course);
            }
            return allCoruses;
        }
    }
}