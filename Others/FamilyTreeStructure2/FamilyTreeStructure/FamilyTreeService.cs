using FamilyTreeStructure.Data;
using FamilyTreeStructure.Interfaces;
using FamilyTreeStructure.Models;
using System;

namespace FamilyTreeStructure
{
    public class FamilyTreeService : IFamilyTree
    {
        private Person person;
        private FamilyTree familyTree;

        public FamilyTreeService(Person p)
        {
            person = p;
            familyTree = new FamilyTree();
        }

        public void ShowFamilyTree()
        {
            Console.WriteLine("Family Details of a Person");
            Console.WriteLine("FirstName = {0} Created date = {1} ", person.ToString(), familyTree.DateOfCreation);

            foreach (var child in person.Childern)
            {
                Console.WriteLine("Children {0} ", child.ToString());
                Console.WriteLine("\n");
            }

            Console.WriteLine("Fathers Name is {0} \t\n Mothers Name {1} ", person.Father.ToString(), person.Mother.ToString());
        }

        public string SearchByName(string searchString)
        {
            var allPeople = PersonData.GetAllPersons();

            foreach (var p in allPeople)
            {
                if (p.LastName == searchString)
                {
                    return p.ToString();
                }
            }

            return "No Person found with the given name";
        }

        public FamilyTree Create()
        {
            FamilyTree familyTree = new FamilyTree();

            familyTree.Person = person;

            return familyTree;
        }
    }
}