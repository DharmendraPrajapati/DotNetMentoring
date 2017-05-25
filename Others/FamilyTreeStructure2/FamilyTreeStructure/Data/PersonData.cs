using FamilyTreeStructure.Models;
using System;
using System.Collections.Generic;

namespace FamilyTreeStructure.Data
{
    public static class PersonData
    {
        public static IList<Person> GetAllPersons()
        {
            var personsList = new List<Person>()
            {
                 new Person()
                 {
                     FirstName = "vamsi", LastName = "jammula", DateOfBirth = Convert.ToDateTime("03/04/1984"), DateOfDeath = null, Sex = Person.Gender.Male
                 },
                 new Person()
                 {
                     FirstName = "Peter", LastName = "North", DateOfBirth = Convert.ToDateTime("03/04/1986"),  DateOfDeath = null, Sex = Person.Gender.Male
                 },
                 new Person()
                 {
                     FirstName = "Angela", LastName = "Duckworth", DateOfBirth = Convert.ToDateTime("03/04/1980"),  DateOfDeath = null, Sex = Person.Gender.Female
                 },
                 new Person()
                 {
                     FirstName = "Jermey", LastName = "Clarkson", DateOfBirth = Convert.ToDateTime("03/04/1970"),  DateOfDeath = null, Sex = Person.Gender.Female
                 },
                 new Person()
                 {
                     FirstName = "Richard", LastName = "Hammond", DateOfBirth = Convert.ToDateTime("03/04/1975"),  DateOfDeath = null, Sex=Person.Gender.Male 
                 },
                 new Person()
                 {
                     FirstName = "James", LastName = "May", DateOfBirth = Convert.ToDateTime("03/04/1970"),  DateOfDeath = null, Sex=Person.Gender.Male
                 }
            };

            return personsList;
        }
    }
}