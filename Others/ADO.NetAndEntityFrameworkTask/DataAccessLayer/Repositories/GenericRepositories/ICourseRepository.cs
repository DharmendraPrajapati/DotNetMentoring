using System.Collections.Generic;

namespace DataAccessLayer.Repositories.GenericRepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopEnrolledCourses(IEnumerable<Course> courses);
    }
}