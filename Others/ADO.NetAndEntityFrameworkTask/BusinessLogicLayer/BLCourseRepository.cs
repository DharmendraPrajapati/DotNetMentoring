using DataAccessLayer.UnitOfWork;

//using Models;

namespace BusinessLogicLayer
{
    public class BlCourseRepository
    {
        public BlCourseRepository()
        {
            
        }
        public BlCourseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; set; }
       
    }
}