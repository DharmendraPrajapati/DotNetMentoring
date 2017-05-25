using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing
{
    struct Person
    {
        private object Age;
        private object Name;

        Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Boxing  which will retrun instance of variable which is refering to Person Object.
            var obj = Boxing();
            // Unboxing
            Unboxing(obj);
        }
        static Person Boxing()
        {
            Person personObj;
            personObj.age = 40; // Assign integer value type to age field which is type of object
            personObj.Name = "Admin"; //Assign Name value type to name field which is type of object
            return personObj;
            // So here Inetger and String value got boxed in Object and again got boxed in Person Type object. which is referenced by personObj instance variable.
        }
        static void Unboxing(object personObj)
        {
            var obj = (Person)personObj; // Unboxing of personObj to Object of Person type.
            int age = obj.age; // Here first obj get unboxed from Person type and then again unboxed with object to integer value type.
            string name = obj.Name; // Here first obj get unboxed from Person type and then agian unboxed with object to string value type.     
            Console.WriteLine("Person Name is " + name + " , age " + age);
            Console.ReadKey();
        }
    }
}
/*

Boxing 
    Convert value type to reference type is called Boxing.
    There are three steps happens for boxing of instance of value type.
    1.	The amount of memory, required by value type fields is allocated from the managed heap rather than stack.
    2.	The Value type fields are copied into allocated memory.
    3.	The Address of the object is returned which is referring to that allocated memory.
    Boxing is implicit process which wrap value inside ‘System.Object’.

Unboxing
    Unboxing is explicit conversion which convert reference type object to value type. In unboxing, boxed value type is unboxed from the heap and assign to a value type and stored in stack.
    
*/
