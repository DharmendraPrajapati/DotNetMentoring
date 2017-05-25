using FamilyTreeStructure.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace FamilyTreeStructure
{
    internal static class Program
    {

        

        private static void Main(string[] args)
        {
            FamilyTree.Create();
            PersonService personService = new PersonService();
            #region Data
            
            var father = new Person { FirstName = "Frank", LastName = "Far", Sex = Person.Gender.Male, DateOfBirth = DateTime.Parse("12/15/1965") };
            var mother = new Person { FirstName = "Noora", LastName = "Jones", Sex = Person.Gender.Female, DateOfDeath = DateTime.Parse("12/27/1955") };
            var father1 = new Person { FirstName = "James", LastName = "May", Sex = Person.Gender.Male, DateOfBirth = DateTime.Parse("07/07/1955") };
            var mother1 = new Person { FirstName = "Anna", LastName = "Pickets", Sex = Person.Gender.Female, DateOfBirth = DateTime.Parse("07/07/1947") };

            var children2 = new List<Person>
            {
                new Person
                {
                    FirstName = "Frank",
                    LastName = "Far",
                    Sex = Person.Gender.Male,
                    DateOfBirth = DateTime.Parse("12/15/1965")
                },
                new Person
                {
                    FirstName = "Noora",
                    LastName = "Jones",
                    Sex = Person.Gender.Female,
                    DateOfDeath = DateTime.Parse("12/27/1955")
                }

            };


            var children = new List<Person>()
            {
                new Person()
                {
                    FirstName="Sam", LastName="Nicoles", Sex = Person.Gender.Male, Father = father1, Mother = mother1,DateOfBirth = DateTime.Parse("12/15/1995"), Income = 1000.25
                    
                },
                new Person() { FirstName="Jane", LastName= "Nicoles",  Sex = Person.Gender.Female , Father = father1, Mother = mother1,DateOfBirth = DateTime.Parse("10/17/1997"),  Income = 1000.25}
            };

            

            var person = new Person() { Childern = children, FirstName = "Norman", LastName = "Lewis", Father = father, Mother = mother, Sex = Person.Gender.Male, DateOfBirth = DateTime.Parse("06/05/1965"), Income = 2000.78};
            #endregion

            FamilyTree familyTree = new FamilyTree
            {
                Person = person,
                Persons = children
            };
            familyTree.ShowFamilyTree();
            personService.Person = person;
            personService.GetFamily();
            Console.WriteLine("Search By Name");
            Console.WriteLine(familyTree.SearchByName("Ni"));
          //  Console.Clear();
            familyTree.ValidatePerson();
            
            Console.Read();
        }
    }
}