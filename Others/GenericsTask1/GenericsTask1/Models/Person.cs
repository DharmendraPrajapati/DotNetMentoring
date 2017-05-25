using System;

namespace GenericsTask1.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public int Rating { get; set; }
        public override string ToString()
        {
            return "Person Details: \n"+"First Name: "+FirstName + "\t"+ "Last Name: " + LastName+"\t"+ "Start Date: " + StartDate.ToShortDateString()+"\t"+"Rating: "+Rating+"\n";
        }
    }
}