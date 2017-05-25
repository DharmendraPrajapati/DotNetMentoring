using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableExample
{
    public class Employee : IDisposable
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public bool _isDisposed = false;
        protected virtual void Dispose(bool disposeFlag)
        {
            if (_isDisposed)
                return;
            else
            {
                if (this.Age != 0)
                {
                    this.Age = 0;
                }
                if (this.Name != null)
                {
                    this.Name = null;
                }
            }            
            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    struct Company : IDisposable
    {
        public int CompId { get; set; }
        public string Name { get; set; }

        public void Dispose()
        {
            CompId = 0;
            Name = null;
        }
    }
    class Program
    {
        public Employee emp { get; set; }
        static void Main(string[] args)
        {
            Employee obj = new Employee { Age=42,Name="Test"};
            Console.WriteLine("Name :" + obj.Name + " and age : " + obj.Age);
            obj.Dispose();
            Company comp = new Company();
            comp.CompId = 1021;
            comp.Name = "ABC";
            Console.WriteLine("Name :" + comp.Name + " and age : " + comp.CompId);
            comp.Dispose();
            Console.ReadKey();
        }
    }
}
