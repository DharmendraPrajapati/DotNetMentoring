using FamilyTreeStructure.Models;
using System;
using System.Collections.Generic;

namespace FamilyTreeStructure
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            FamilyTree.Create();
            var personService = new PersonService();

            #region Data

            var father = new Person
                         {
                             FirstName = "Frank",
                             LastName = "Far",
                             Sex = Gender.Male,
                             DateOfBirth = DateTime.Parse("12/15/1965")
                         };
            var mother = new Person
                         {
                             FirstName = "Noora",
                             LastName = "Jones",
                             Sex = Gender.Female,
                             DateOfDeath = DateTime.Parse("12/27/1955")
                         };
            var father1 = new Person
                          {
                              FirstName = "James",
                              LastName = "May",
                              Sex = Gender.Male,
                              DateOfBirth = DateTime.Parse("07/07/1955")
                          };
            var mother1 = new Person
                          {
                              FirstName = "Anna",
                              LastName = "Pickets",
                              Sex = Gender.Female,
                              DateOfBirth = DateTime.Parse("07/07/1947")
                          };
            var children2 = new List<Person>
                            {
                                new Person
                                {
                                    FirstName = "Frank",
                                    LastName = "Far",
                                    Sex = Gender.Male,
                                    DateOfBirth = DateTime.Parse("12/15/1965")
                                },
                                new Person
                                {
                                    FirstName = "Noora",
                                    LastName = "Jones",
                                    Sex = Gender.Female,
                                    DateOfDeath = DateTime.Parse("12/27/1955")
                                }
                            };
            var children = new List<Person>
                           {
                               new Person
                               {
                                   FirstName = "Sam",
                                   LastName = "Nicoles",
                                   Sex = Gender.Male,
                                   Father = father1,
                                   Mother = mother1,
                                   DateOfBirth = DateTime.Parse("12/15/1995"),
                                   Income = 1000.25
                               },
                               new Person
                               {
                                   FirstName = "Jane",
                                   LastName = "Nicoles",
                                   Sex = Gender.Female,
                                   Father = father1,
                                   Mother = mother1,
                                   DateOfBirth = DateTime.Parse("10/17/1997"),
                                   Income = 1000.25
                               }
                           };
            var person = new Person
                         {
                             Childern = children,
                             FirstName = "Norman",
                             LastName = "Lewis",
                             Father = father,
                             Mother = mother,
                             Sex = Gender.Male,
                             DateOfBirth = DateTime.Now.AddYears(-5),
                             Income = 2000.78
                         };

            #endregion Data

            var familyTree = new FamilyTree
                             {
                                 Person = person,
                                 Persons = children
                             };
            familyTree.ShowFamilyTree();
            personService.Person = person;
            personService.GetFamily();
            Console.WriteLine("Search By Name");
            Console.WriteLine(familyTree.SearchByName("Ni"));
            var inValidProps = person.Validate();
            Console.WriteLine("Validation Errors");
            foreach(var validationResult in inValidProps)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
            Console.Read();
        }
    }
}