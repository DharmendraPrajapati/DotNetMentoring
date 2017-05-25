using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.ADO;

namespace ConsoleApp
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
           //ADORepository<Course> courseRepository = new ADORepository<Course>();

            AdoNetUnitOfWork unitOfWork = new AdoNetUnitOfWork();

            var data = unitOfWork.Courses.GetAll();

            foreach(var course in data)
            {

                Console.WriteLine(course.Title);
            }

            Console.Read();
        }
    }
}
