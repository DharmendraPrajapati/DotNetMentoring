using System;
using System.Collections.Generic;
using System.Text;
using FamilyTreeStructure.Interfaces;
using FamilyTreeStructure.Models;

namespace FamilyTreeStructure
{
    public class PersonService : IPersonService
    {
        private readonly StringBuilder _sb;

        //TODO: Avoid using publid fields. If you don't want a property then keep the private variable.
        public PersonService()
        {
            Person = new Person();
            _sb = new StringBuilder();
        }

        public Person Person { get; set; }

        public void AddChild(Person child)
        {
            Person.Childern.Add(child);
        }

        public void AddChildren(List<Person> children)
        {
            Person.Childern.AddRange(children);
        }

        public void GetFamily()
        {
            _sb.Append("Out put Using StringBuilder class" + "\n\n");
            _sb.Append(Person.FirstName + "," + Person.LastName);
            _sb.Append(Environment.NewLine);
            if (Person.Childern != null)
            {
                _sb.Append("Children Details" + "\n\n");
                foreach (var person in Person.Childern)
                    _sb.Append(person.FirstName + "," + person.LastName + "\n");
            }
            Console.WriteLine(_sb.ToString());
            _sb.Clear();
        }

        public void AddParent(Person parent)
        {
            //TODO: No need to be else. I think you can just have else
            if (parent.Sex == Person.Gender.Male)
                Person.Father = parent;
        }
    }
}