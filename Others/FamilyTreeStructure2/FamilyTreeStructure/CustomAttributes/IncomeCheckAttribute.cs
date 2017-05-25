using FamilyTreeStructure.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyTreeStructure.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IncomeCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;
            if(value is DateTime)
            {
                var inputValue = (DateTime)value;
                if(DateTime.Now.Year - inputValue.Year < 18)
                {
                    if(person.Income > 0)
                    {
                        return
                            new ValidationResult($"Age Should Be > 18 for the person to have Income");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}