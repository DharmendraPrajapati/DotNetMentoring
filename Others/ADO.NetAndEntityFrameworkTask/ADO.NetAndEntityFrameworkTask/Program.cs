using System;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;

namespace UILayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var courseRepository = new UnitOfWork(new SchoolEntitiesContext());
            var data = courseRepository.Courses.GetAll();
            foreach (var course in data)
            {
                Console.WriteLine(course.ToString());
            }
            Console.Read();
        }
    }
}