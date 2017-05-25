using System;
using System.Collections.Generic;
using System.Linq;
using FamilyTreeStructure.Interface;

namespace FamilyTreeStructure.ModelClasses
{
    public class FamilyTree : IFamilyTree
    {
        public DateTime DateOfCreation { get; private set; }
        public Person Person { get; set; }

        private static FamilyTree _familyRoot;
        
        public FamilyTree Create()
        {
            _familyRoot = new FamilyTree
            {
                Person = CreateFirstPerson(),
                DateOfCreation = DateTime.Now
            };
            return _familyRoot;
        }

        public string SearchByName(string searchKey)
        {
            var searchResult = SearchPersonName(searchKey);
            var enumerable = searchResult as IList<Person> ?? searchResult.ToList();

            if (enumerable.Count() == 0)
            {
                Console.WriteLine("No result Found which starts with searck Key ..... Please see the family tree.");
                ShowTree();
                return string.Empty;
            }

            foreach (var person in enumerable)
            {
                Console.WriteLine(person.ToString());
            }

            return string.Empty;
        }

        public void ShowTree()
        {
            if (_familyRoot == null)
            {
                return;
            }

            const int level = 0;
            Console.WriteLine($"{new string('\t', level)}{_familyRoot.Person.FirstName} {_familyRoot.Person.LastName} {_familyRoot.Person.Income}");
            PrintChild(_familyRoot.Person, level);
        }

        public void GetFamily()
        {
            _familyRoot?.Person.GetFamily();
        }

        

        private static string GetPersonName(Person personObj)
        {
            return personObj.FirstName + " " + personObj.LastName;
        }
        public void GetFamilyIncome()
        {
            Console.WriteLine(GetPersonName(_familyRoot.Person) + " " + _familyRoot.Person.GetIncome());
        }
        
        private static void PrintChild(Person person, int level)
        {
            if (!person.ListOfChilds.Any())
            {
                return;
            }

            //SetIncomeBasedOnAge(person);
            level ++;

            foreach (var child in person.ListOfChilds)
            {
                Console.WriteLine($"{new string('\t', level)}{child.FirstName} {child.LastName}");
                PrintChild(child, level);
            }
        }

        private static IEnumerable<Person> SearchPersonName(string searchKey)
        {
            var searchedPeople = new List<Person>();

            if (_familyRoot == null)
            {
                return searchedPeople;
            }

            searchedPeople = SearchForPerson(searchKey, _familyRoot.Person, searchedPeople).ToList();

            return searchedPeople;
        }
        
        private static IEnumerable<Person> SearchForPerson(string searchKey, Person personObj, IList<Person> searchedPeople)
        {
            if (personObj.FirstName.StartsWith(searchKey,StringComparison.OrdinalIgnoreCase) || personObj.LastName.StartsWith(searchKey, StringComparison.OrdinalIgnoreCase))
            {
                searchedPeople.Add(personObj);
            }

            foreach (var child in personObj.ListOfChilds)
            {
                searchedPeople = SearchForPerson(searchKey, child, searchedPeople).ToList();
            }

            return searchedPeople;
        }

        private static Person CreateFirstPerson()
        {
            var person = new Person
            {
                FirstName = "Root",
                LastName = "Root",
                ListOfChilds = GetChild("Child", "1970-07-15"),
                DateOfBirth = Convert.ToDateTime("1940-05-05"),
                Gender = GenderEnum.Male,
                Income = 500,
                Father = new Person { FirstName = "Father_fname",LastName = "Father_lname" },
                Mother = new Person { FirstName = "Mother_fname", LastName = "Mother_lname" }
            };

            return person;
        }
        
        private static IList<Person> GetChild(string name,string dateOfBirth)
        {
            var childs = new List<Person>();

            for (var i = 0; i < 3; i++)
            {
                var person = new Person
                {
                    FirstName = $"{i + 1}{name}",
                    LastName = $"{i + 1}{name}",
                    ListOfChilds = GetChildrens("Grand_Child", 3,"2012-10-10"),
                    DateOfBirth = Convert.ToDateTime(dateOfBirth),
                    DateOfDeath = DateTime.Now,
                    Income = 1000,
                    Father =
                        new Person
                        {
                            FirstName = $"{name}{i + 1}" + "'s Father",
                            Gender = GenderEnum.Male,
                            ListOfChilds = GetChildrens("Grand_Children", 3, "2012-10-10")
                        },
                    Mother =
                        new Person
                        {
                            FirstName = $"{name}{i + 1}" + "'s Mother",
                            Gender = GenderEnum.Female,
                            ListOfChilds = GetChildrens("Grand_Children", 3,"2002-10-10")
                        },
                    Gender = GenderEnum.Male
                };

                childs.Add(person);
            }

            return childs;
        }

        private static IList<Person> GetChildrens(string name, int count, string dateOfBirth)
        {
            var childs = new List<Person>();

            for (var i = 0; i < count; i++)
            {
                var person = new Person
                {
                    FirstName = $"{name}_FN{i + 1}",
                    LastName = $"{name}_LN{i + 1}",
                    ListOfChilds = new List<Person>(),
                    DateOfBirth = Convert.ToDateTime(dateOfBirth),
                    Income = 5000,
                    Father =
                        new Person
                        {
                            FirstName = $"{name}{i + 1}" + "'s Father",
                            Gender = GenderEnum.Male,
                            ListOfChilds = new List<Person>()
                        },
                    Mother =
                        new Person
                        {
                            FirstName = $"{name}{i + 1}" + "'s Mother",
                            Gender = GenderEnum.Female,
                            ListOfChilds = new List<Person>()
                        },
                    Gender = GenderEnum.Male
                };

                childs.Add(person);
            }

            return childs;
        }
    }
}
