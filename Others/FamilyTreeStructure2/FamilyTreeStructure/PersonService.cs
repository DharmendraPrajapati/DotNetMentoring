using FamilyTreeStructure.Interfaces;
using FamilyTreeStructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTreeStructure
{
    public class PersonService : IPersonService
    {
        private readonly StringBuilder _stringBuilder;

        public PersonService()
        {
            Person = new Person();
            _stringBuilder = new StringBuilder();
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
            _stringBuilder.Append("Out put Using StringBuilder class" + "\n\n");
            _stringBuilder.Append(Person.FirstName + "," + Person.LastName);
            _stringBuilder.Append(Environment.NewLine);
            if(Person.Childern != null)
            {
                _stringBuilder.Append("Children Details" + "\n\n");
                foreach(var person in Person.Childern)
                {
                    _stringBuilder.Append(person.FirstName + "," + person.LastName + "\n");
                }
            }
            Console.WriteLine(_stringBuilder.ToString());
            _stringBuilder.Clear();
        }

        public void AddParent(Person parent)
        {
            if(parent.Sex == Gender.Male)
            {
                Person.Father = parent;
            }
            else if(parent.Sex == Gender.Female)
            {
                Person.Mother = parent;
            }
        }
    }
}