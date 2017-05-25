using GenericsTask1.Models;
using System;
using System.Collections.Generic;

namespace GenericsTask1.DataRepositories
{
    public static class PersonsRepository
    {
        public static IList<Person> GetAllPersons()
        {
            return new List<Person>
            {
                new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    StartDate = DateTime.Now,
                    Rating = 4
                },
                new Person
                {
                    FirstName = "Sam",
                    LastName = "Smith",
                    StartDate = DateTime.Now,
                    Rating = 5
                }
            };
        }
    }
}