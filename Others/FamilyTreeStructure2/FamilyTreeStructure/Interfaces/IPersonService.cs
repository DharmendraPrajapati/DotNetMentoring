using FamilyTreeStructure.Models;
using System.Collections.Generic;

namespace FamilyTreeStructure.Interfaces
{
    public interface IPersonService
    {
        string ToString();

        void AddParent(Person parent);

        void AddChild(Person child);

        void AddChildren(List<Person> childern);

        void GetFamily();
    }
}