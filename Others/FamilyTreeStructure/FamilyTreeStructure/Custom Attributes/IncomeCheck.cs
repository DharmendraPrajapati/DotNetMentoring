using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FamilyTreeStructure.Custom_Attributes
{
   // [AttributeUsage(AttributeTargets.Class, AllowMultiple =false, Inherited =false)]
    public class IncomeCheck:Attribute

    {
    	//TODO: I don't think it's not much use having a properties. You can just have method
        public DateTime DateOfBirth { get; set; }        

        public float? Income { get; set; }



        public IncomeCheck(DateTime dateOfBirth, float? income)
        {
            DateOfBirth = dateOfBirth;
            Income = income;

            var age = DateTime.Today.Year - DateOfBirth.Year;

            if (Income != null)
            {

                if (age < 18 && Income == 0)
                {
                    throw new Exception("Person with age less than 18 cannot have income");
                }

            }
        }
    }
}
