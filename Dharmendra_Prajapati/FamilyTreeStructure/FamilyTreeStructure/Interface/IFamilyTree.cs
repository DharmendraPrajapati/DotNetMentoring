using System.Security.Cryptography.X509Certificates;
using FamilyTreeStructure.ModelClasses;

namespace FamilyTreeStructure.Interface
{
    public interface IFamilyTree
    {
        // TODO: separate method declarations by a blank line
        FamilyTree Create();
        void ShowTree();
        string SearchByName(string searchKey);
        void GetFamilyIncome();
        void GetFamily();
    }
}
