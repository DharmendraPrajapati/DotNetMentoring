using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class Employee : IDisposable
    {
        public int age;
        public string Name;
        public Employee(int a, string n)
        {
            age = a;
            Name = n;
        }

        public void Dispose()
        {
            age = 0;
            Name = null;
            Console.WriteLine("After Dispose, Name :" + Name + " and age : " + age);
        }
    }
    class DisposibleExample
    {
        public Employee emp { get; set; }
        static void Main(string[] args)
        {
            Employee obj = new Employee(35,"Test");
            Console.WriteLine("Name :" + obj.Name + " and age : " + obj.age);
            obj.Dispose();
            Console.ReadKey();
        }
        
    }
}
