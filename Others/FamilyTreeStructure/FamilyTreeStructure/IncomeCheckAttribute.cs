using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using FamilyTreeStructure.Models;

namespace FamilyTreeStructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IncomeCheckAttribute : ValidationAttribute
    //Attribute
    {
        

        private int Age { get; set; }
        public string Message { get; set; }

        public DateTime DateOfBirth { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                DateOfBirth = Convert.ToDateTime(value.ToString());
            }

            if (DateOfBirth.Year - DateTime.Today.Year < 18)
            {
                Message = "Age is < 18";
                return new ValidationResult(Message);
            }
            Message = "Age is > 18";
            return ValidationResult.Success;
        }
        
    }
}
