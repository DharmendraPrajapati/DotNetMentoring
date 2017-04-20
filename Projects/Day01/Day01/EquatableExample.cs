using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public struct Student : IEquatable<Student>
    {
        public int BatchId { get; set; }
        public string Name { get; set; }

        public bool Equals(Student other)
        {            
            if (this.Name.Equals(other.Name) && this.BatchId.Equals(other.BatchId))
            {
                return true;
            }
            return false;
        }        
    }
    class EquatableExample
    {
        static void Main(string[] args)
        {
            Student s1 = new Student { Name = "Test1", BatchId = 121 };
            Student s2 = new Student { Name = "Test2", BatchId = 121 };

            Console.WriteLine(s1.Equals(s2));
            Console.ReadKey();
        }
    }
}
