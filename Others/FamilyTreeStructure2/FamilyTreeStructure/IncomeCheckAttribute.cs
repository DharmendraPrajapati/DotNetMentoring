using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyTreeStructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IncomeCheckAttribute : ValidationAttribute       
    {
        public DateTime DateOfBirth { get; set; }
        private string Message { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
                DateOfBirth = Convert.ToDateTime(value.ToString());
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