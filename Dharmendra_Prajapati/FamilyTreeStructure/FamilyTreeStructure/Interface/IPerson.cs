using System.Collections.Generic;
using FamilyTreeStructure.ModelClasses;

namespace FamilyTreeStructure.Interface
{
    public interface IPerson
    {
        // TODO: separate method declarations by a blank line
        string ToString();
        void AddParent(Person parent);
        void AddChild(Person child);
        void AddChilds(IList<Person> childs);
        void GetFamily();
        int GetIncome();
    }
}
