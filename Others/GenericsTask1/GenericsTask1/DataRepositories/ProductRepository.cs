using GenericsTask1.Models;
using System;
using System.Collections.Generic;

namespace GenericsTask1.DataRepositories
{
    public static class ProductRepo
    {
        public static IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Personal Computer",
                    Description = "Windows PC",
                    MaufacturedDate = DateTime.Now.AddMonths(-2),
                    Rating = 4
                },
                new Product
                {
                    Id = 2,
                    Name = "Tablet Computer",
                    Description = "Android PC",
                    MaufacturedDate = DateTime.Now.AddDays(-7),
                    Rating = 3
                }
            };
        }
    }
}