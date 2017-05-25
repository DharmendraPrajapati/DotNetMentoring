using FamilyTreeStructure.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FamilyTreeStructure.Models
{
    public class Person
    {
        private readonly StringBuilder _stringBuilder;

        public Person()
        {
            _stringBuilder = new StringBuilder();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [IncomeCheck]
        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }
        public Gender Sex { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public List<Person> Childern { get; set; }
        public double? Income { get; set; }

        public override string ToString()
        {
            if(Income != null)
            {
                _stringBuilder.Append("Income: " + Income + "\n");
            }
            if(DateOfDeath.HasValue)
            {
                var dod = Convert.ToDateTime(DateOfDeath);
                _stringBuilder.Append("Date Of Death: " + dod.ToShortDateString() + "\n");
            }
            _stringBuilder.Append("FirstName: " + FirstName + "\t" + " Last Name: " + LastName + "\t" +
                                  "Date Of Birth: " + DateOfBirth.ToShortDateString() + "\t " + "Gender: " + Sex);
            return _stringBuilder.ToString();
        }

        public List<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null);
            var isValid = Validator.TryValidateObject
                (this, vc, validationResults, true);
            return validationResults;
        }
    }
}