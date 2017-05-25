
﻿using System;

using FamilyTreeStructure.Custom_Attributes;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FamilyTreeStructure.Models
{
       
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public Gender Sex { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public List<Person> Childern { get; set; }
        public double? Income { get; set; }
        private readonly StringBuilder _stringBuilder;
        public enum Gender
        {
            Male,
            Female

        }

        public Person()
        {
                _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {

            if (Income != null)
            {
                _stringBuilder.Append("Income: " + Income + "\n");
            }


        	//TODO: You can use ? operator syntax instead of below logic

            if (DateOfDeath.HasValue)
            {
                DateTime dod = Convert.ToDateTime(DateOfDeath);

                _stringBuilder.Append("Date Of Death: " + dod.ToShortDateString()+"\n");
                
            }

            _stringBuilder.Append("FirstName: " + FirstName + "\t" + " Last Name: " + LastName + "\t" +
                                  "Date Of Birth: " + DateOfBirth.ToShortDateString() + "\t " + "Gender: " + Sex);

            return _stringBuilder.ToString();
        }
    }
}