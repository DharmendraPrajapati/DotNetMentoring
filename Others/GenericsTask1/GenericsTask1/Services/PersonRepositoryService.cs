using System.Collections.Generic;
using System.Linq;
using GenericsTask1.DataRepositories;
using GenericsTask1.GenericRepository;
using GenericsTask1.Models;

namespace GenericsTask1.Services
{
    public class PersonRepositoryService : IRepository<Person, string>
    {
        private readonly List<Person> _allpersons;

        public PersonRepositoryService()
        {
            _allpersons = PersonsRepository.GetAllPersons().ToList();
        }

        public PersonRepositoryService(List<Person> persons)
        {
            _allpersons = PersonsRepository.GetAllPersons().ToList();
        }

        public IEnumerable<Person> GetItems()
        {
            return _allpersons;
        }

        public Person GetItem(string key)
        {
            return _allpersons.FirstOrDefault(person => person.LastName == key);
        }

        public void Add(Person item)
        {
            _allpersons.Add(item);
        }

        public void AddRange(IEnumerable<Person> items)
        {
            _allpersons.AddRange(items);
        }

        public void Update(string tKey, Person item)
        {
            var personToUpdate = GetItem(tKey);
            if(personToUpdate == null)
            {
                return;
            }
            personToUpdate.FirstName = item.FirstName;
            personToUpdate.LastName = item.LastName;
            personToUpdate.Rating = item.Rating;
            personToUpdate.StartDate = item.StartDate;
        }

        public void Delete(string tKey)
        {
            var personToRemove = GetItem(tKey);
            _allpersons.Remove(personToRemove);
        }

        public int Count()
        {
            return _allpersons.Count;
        }
    }
}