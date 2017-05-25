using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyTreeStructure.ModelClasses
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal sealed class CheckAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext contextObj)
        {
            var personObj = contextObj.ObjectInstance as Person;

            if (!(value is DateTime))
            {
                return ValidationResult.Success;
            }
            var age = DateTime.Today.Year - ((DateTime) value).Year;

            if (age >= 18)
            {
                return ValidationResult.Success;
            }

            if (personObj != null && (personObj.Income > 0 && personObj.Income != null))
            {
                return new ValidationResult($"Age Should Be > 18 for {personObj.FirstName} {personObj.LastName} to have Income");
            }

            return ValidationResult.Success;
        }
    }
}