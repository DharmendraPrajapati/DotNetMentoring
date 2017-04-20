using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareObject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Company objFirst = new Company() { CompanyId = 1254256, Name = "Epam", Address = "Hyderabad", NoOfEmployees = 800 };
            Company objSecond = new Company() { CompanyId = 12542567, Name = "Epam", Address = "Hyderabad", NoOfEmployees = 800 };
            var objThird = objSecond;

            Console.WriteLine(objFirst.Equals(objSecond));
            Console.WriteLine(objThird.GetHashCode()); //Check the hash Code
            Console.WriteLine(objSecond.GetHashCode());
            Console.ReadKey();
        }
    }
    class Company : IEquatable<Company>
    {
        public Int32 CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NoOfEmployees { get; set; }

        // This is Interface method.
        public bool Equals(Company other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.Name.Equals(other.Name))
            {
                return true;
            }
            return false;
        }
        /// This is Object Class method
        public override bool Equals(Object obj)
        {
            var other = obj as Company;
            return this.Equals(other);
        }
        public override int GetHashCode()
        {
            return this.CompanyId; // Here Provide unique Identifier for Object
        }
    }
}
