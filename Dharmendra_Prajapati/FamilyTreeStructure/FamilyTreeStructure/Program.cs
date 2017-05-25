using System;
using FamilyTreeStructure.ModelClasses;

namespace FamilyTreeStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var family = new FamilyTree();
            family = family.Create();

            Console.WriteLine("Press (1) for Show Tree, (2) for Search in the Family, (3) for Get Family, (4) for Get income of Family.");
            try
            {
                var input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)ChoiceEnum.Show:
                    {
                        family.ShowTree();

                        break;
                    }
                    case (int)ChoiceEnum.Search:
                    {
                        Console.WriteLine("Enter First/Last Name starts with: ");
                        var readLine = Console.ReadLine();

                        if (readLine != null)
                        {
                            family.SearchByName(readLine);
                        }

                        break;
                    }
                    case (int)ChoiceEnum.GetFamily:
                        {
                            family.GetFamily();

                            break;
                        }
                    case (int)ChoiceEnum.GetIncome:
                        {
                            family.GetFamilyIncome();

                            break;
                        }
                    default:
                    {
                        Console.WriteLine("Wrong Choice ... Bye");
                        break;
                    }
                }
                Console.WriteLine("\n Income Validation for Persons");
                var validations = family.Person.PersonValidation();
                foreach (var validateResult in validations)
                {
                    Console.WriteLine(validateResult);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Bye");
            }
        }
    }
}
