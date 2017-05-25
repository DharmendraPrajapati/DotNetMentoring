using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsTask1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime MaufacturedDate { get; set; }
        public int Rating { get; set; }

       

        public override string ToString()
        {
            return "Product Details: \n" + "Id: " + Id + "\t" + "Name: " + Name + "\t" + "Description: " + Description +
                   "\t" + "Maufactured Date: " + MaufacturedDate.ToShortDateString() + "\t" + "Rating: " + Rating + "\n";
        }

       

       

    }

   
}