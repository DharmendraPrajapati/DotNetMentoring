using FamilyTreeStructure.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace FamilyTreeStructure.Models
{
    public class FamilyTree : IFamilyTree
    {
        private static StringBuilder _stringBuilder;
        private static FamilyTree _instanceFamilyTree;
        private DateTime _dateOfCreation;
        public List<Person> Persons { get; set; }
        public Person Person { get; set; }
        public DateTime DateOfCreation => DateTime.Now;
        public FamilyTree()
        {
            Person = new Person
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Childern = new List<Person>(),
                Sex = Person.Gender.Male,
                Income = double.MinValue,
                DateOfBirth = DateTime.Now.AddYears(-30),
                Mother = new Person(),
                Father = new Person(),
                DateOfDeath = null
            };
            _stringBuilder = new StringBuilder();
            _dateOfCreation = DateTime.Now;
            _instanceFamilyTree = this;
            Persons = new List<Person>();
        }

        public void ShowFamilyTree()
        {
            _stringBuilder.Append("Persons Details\n");
            if (Person != null)
            {
                _stringBuilder.Append(Person + "\n");
                _stringBuilder.Append("Fathers Details \n" + Person.Father + "\n");
                _stringBuilder.Append("Mothers Details \n" + Person.Mother + "\n");
            }
            else
            {
                _stringBuilder.Append(Person + "\n");
            }
            if (Person.Childern == null)
                return;
            _stringBuilder.Append("Children Details \n");
            for (var i = 0; i < Person.Childern.Count; i++)
            {
                ConstructFamilyTree(Person.Childern[i], false);
                _stringBuilder.Append("Child: " + (i + 1));
                _stringBuilder.Append("--" + Person.Childern[i] + "\n");
                if (Person.Childern[i].Income != null)
                    Person.Income += Person.Childern[i].Income;
            }
            Console.WriteLine(_stringBuilder.ToString());
        }


        public void ValidatePerson()
        {

            var type = Person.GetType();
            var properties = type.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute.GetType() == typeof(IncomeCheckAttribute))
                    {
                        var attr = (IncomeCheckAttribute)attribute;




                    }
                }

            }



        }

        public string SearchByName(string searchString)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append("Search Result Using string Builder" + "\n");
            foreach (var p in Persons)
            {
                var matched = new List<Person>();
                if (p.LastName.Contains(searchString))
                {
                    matched.Add(p);
                    foreach (var person in matched)
                    {
                        _stringBuilder.Append("FirstName: " + person.FirstName + "\t" + "Last Name: " + person.LastName + "\n");
                    }
                }
            }
            return _stringBuilder.ToString();
        }

        public static FamilyTree Create()
        {
            return _instanceFamilyTree ?? (_instanceFamilyTree = new FamilyTree());
        }

        private static void ConstructFamilyTree(Person person, bool isLastChild)
        {
            if (person.Childern == null) return;
            for (var i = 0; i < person.Childern.Count; i++)
            {
                ConstructFamilyTree(person.Childern[i], i == person.Childern.Count - 1);
                Console.WriteLine(person.Childern[i]);
            }
        }


    }
}