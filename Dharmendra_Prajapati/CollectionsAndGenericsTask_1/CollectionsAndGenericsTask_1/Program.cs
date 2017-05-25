using System;
using System.Collections.Generic;
using System.Text;
using CollectionsAndGenericsTask_1.Models;

namespace CollectionsAndGenericsTask_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var std = new Person<Student> {PersonId = "1001",Age = 25,Type = new Student {StudentFName = "Abhay",StudentLName = "Chaudhry"} };
            var std1 = new Person<Student> { PersonId = "1002", Age = 25, Type = new Student { StudentFName = "Abhay", StudentLName = "Chaudhry" } };
            var std2 = new Person<Student> { PersonId = "1003", Age = 25, Type = new Student { StudentFName = "Abhay", StudentLName = "Chaudhry" } };
            var studentsColletion = new[] {std1,std2};

            var emp = new Person<Employee> { PersonId = "1004", Age = 35, Type = new Employee() { EmployeeFName = "abhijeet", EmployeeLName = "Chaudhry" } };
            var emp1 = new Person<Employee> { PersonId = "1005", Age = 35, Type = new Employee() { EmployeeFName = "abhijeet", EmployeeLName = "Chaudhry" } };
            var emp2 = new Person<Employee> { PersonId = "1006", Age = 35, Type = new Employee() { EmployeeFName = "abhijeet", EmployeeLName = "Chaudhry" } };
            var employeeColletion = new[] { emp1, emp2 };

            var personsStd1 = new MyCollection<Person<Student>>(1);
            var students = personsStd1.Add(std);
            var personEmp1 = new MyCollection<Person<Employee>>(1);
            var employees = personEmp1.Add(emp);

            PrintStudent(students);
            PrintEmployee(employees);

            var personsStd2 = new MyCollection<Person<Student>>(2);
            var students1 = personsStd2.AddRange(studentsColletion);
            var personEmp2 = new MyCollection<Person<Employee>>(2);
            var employee2 = personEmp2.AddRange(employeeColletion);

            Console.WriteLine("**");
            Console.WriteLine("**");
            PrintStudent(students1);
            PrintEmployee(employee2);


            Console.WriteLine("**");
            students1 = personsStd2.Remove(std1);
            PrintStudent(students1);
            employee2 = personEmp2.RemoveAt(1);
            PrintEmployee(employee2);

            Console.ReadLine();
        }

        private static void PrintStudent(IEnumerable<Person<Student>> students)
        {
            foreach (var s in students)
            {
                if (s == null)
                {
                    continue;
                }

                var str = new StringBuilder();
                str.Append("Person id :" + s.PersonId + " Age " + s.Age + " Student lastname " + s.Type.StudentLName);
                Console.WriteLine(" Type " + s.GetType());
                Console.WriteLine(str.ToString());
            }
        }
        
        private static void PrintEmployee(IEnumerable<Person<Employee>> employee)
        {
            foreach (var e in employee)
            {
                if (e == null)
                {
                    continue;
                }

                var str = new StringBuilder();
                str.Append("Person id :" + e.PersonId + " Age " + e.Age + " Employee lastname " + e.Type.EmployeeLName);
                Console.WriteLine(" Type " + e.GetType());
                Console.WriteLine(str.ToString());
            }
        }
    }
}
