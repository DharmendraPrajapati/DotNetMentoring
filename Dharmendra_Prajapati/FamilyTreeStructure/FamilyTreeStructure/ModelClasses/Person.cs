using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FamilyTreeStructure.Interface;

namespace FamilyTreeStructure.ModelClasses
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [CheckAge]
        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public Person Father { get; set; }

        public Person Mother { get; set; }

        public IList<Person> ListOfChilds { get; set; }

        public GenderEnum Gender { get; set; }
        
        public int? Income { get; set; }

        public void AddParent(Person parent)
        {
            switch (parent.Gender)
            {
                case GenderEnum.Female:
                    Mother = parent;
                    break;
                case GenderEnum.Male:
                    Father = parent;
                    break;
                default:
                {
                    throw new Exception("Choice not Defined.");
                }
            }
        }

        public void AddChild(Person child)
        {
            if (ListOfChilds != null)
            {
                ListOfChilds.Add(child);
            }
            else
            {
                ListOfChilds = new List<Person> { child };
            }
        }

        public void AddChilds(IList<Person> childs)
        {
            foreach (var child in childs)
            {
                AddChild(child);
            }
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(FirstName).Append(" " + LastName).Append(" " + DateOfBirth.ToString("dd/mm/yyyy"));
            return DateOfDeath != null
                ? str.Append(" " + DateOfDeath).ToString()
                : str.ToString();
        }

        public void GetFamily()
        {
            var familyName = new StringBuilder();
            familyName.Append(GetPersonInfo(Father));
            familyName.Append(", ");
            familyName.Append(GetPersonInfo(Mother));

            foreach (var child in ListOfChilds)
            {
                familyName.Append(", " + GetPersonInfo(child));
            }

            Console.WriteLine(familyName.ToString());
            familyName.Clear();

            foreach (var child in ListOfChilds)
            {
                child.GetFamily();
            }
        }
        
        public int GetIncome()
        {
            var incomeSum = 0;
            incomeSum = PrintFamilyIncome(incomeSum);
            return incomeSum;
        }
        private int PrintFamilyIncome(int incomeSum)
        {
            incomeSum += Income ?? 0;
            incomeSum += Father.Income ?? 0;
            incomeSum += Mother.Income ?? 0;

            if (ListOfChilds == null)
            {
                return incomeSum;
            }

            foreach (var child in ListOfChilds)
            {
                incomeSum = child.PrintFamilyIncome(incomeSum);
            }

            return incomeSum;
        }

        private static string GetPersonInfo(Person personObj)
        {
            return $"{personObj.FirstName} {personObj.LastName}";
        }

        public IList<ValidationResult> PersonValidation()
        {
            var validations = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), validations, true);

            return validations;
        }
    }
}
