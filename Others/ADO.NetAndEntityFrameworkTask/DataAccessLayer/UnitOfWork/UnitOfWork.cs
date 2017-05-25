using System.Data.Entity;
using DataAccessLayer.Repositories.CourseRepositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ICourseRepository Courses { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}