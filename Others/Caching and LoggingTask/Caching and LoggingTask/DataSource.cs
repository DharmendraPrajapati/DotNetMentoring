using System;
using System.Collections.Generic;

namespace CachingAndLoggingTask
{
    public static class DataSource
    {
        public static List<Product> GetAllProducts()
        {
            Console.WriteLine("Products from Repository");
            return new List<Product>
                   {
                       new Product
                       {
                           ProductId = 1,
                           ProductName = "Chai",
                           Category = "Beverages",
                           UnitPrice = 18.0000M,
                           UnitsInStock = 39
                       },
                       new Product
                       {
                           ProductId = 2,
                           ProductName = "Chang",
                           Category = "Beverages",
                           UnitPrice = 19.0000M,
                           UnitsInStock = 17
                       },
                       new Product
                       {
                           ProductId = 3,
                           ProductName = "Aniseed Syrup",
                           Category = "Condiments",
                           UnitPrice = 10.0000M,
                           UnitsInStock = 13
                       },
                       new Product
                       {
                           ProductId = 4,
                           ProductName = "Chef Anton's Cajun Seasoning",
                           Category = "Condiments",
                           UnitPrice = 22.0000M,
                           UnitsInStock = 53
                       },
                       new Product
                       {
                           ProductId = 5,
                           ProductName = "Chef Anton's Gumbo Mix",
                           Category = "Condiments",
                           UnitPrice = 21.3500M,
                           UnitsInStock = 0
                       },
                       new Product
                       {
                           ProductId = 6,
                           ProductName = "Grandma's Boysenberry Spread",
                           Category = "Condiments",
                           UnitPrice = 25.0000M,
                           UnitsInStock = 120
                       }
                   };
        }
    }
}