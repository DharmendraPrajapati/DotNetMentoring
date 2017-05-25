using GenericsTask1.Models;
using GenericsTask1.Services;
using System;
using System.Collections.Generic;

namespace GenericsTask1
{
    internal sealed class Program
    {
        private static void Main()
        {
            var personRepositoryService = new PersonRepositoryService();
            var productRepositoryService = new ProductRepositoryService();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nImplementation of IRepository<Person,string>\n");
            var persons = personRepositoryService.GetItems();
            foreach(var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
            var products = productRepositoryService.GetItems();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nImplementation of IRepository<Product,int>\n");
            foreach(var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            var ps = new GenericIEnum<object>(3)
                     {
                         new Person
                         {
                             FirstName = "John",
                             LastName = "Doe",
                             StartDate = DateTime.Now,
                             Rating = 4
                         },
                         new Product
                         {
                             Id = 1,
                             Name = "Personal Computer",
                             Description = "Windows PC",
                             MaufacturedDate = DateTime.Now.AddMonths(-2),
                             Rating = 4
                         },
                         new Person
                         {
                             FirstName = "Sam",
                             LastName = "Smith",
                             StartDate = DateTime.Now,
                             Rating = 5
                         }
                     };
            
            foreach(var o in ps)
            {
                Console.WriteLine(o.ToString());
            }

            List<Product> prd = new List<Product>() 
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
                              Name = "Mobile Phone",
                              Description = "Android",
                              MaufacturedDate = DateTime.Now.AddMonths(-2),
                              Rating = 5
                          }
                      };

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nOutput from Implementation of IEnumerator\n");


            Products prds = new Products(prd);

            foreach(var product in prds)
            {
                Console.WriteLine(product.ToString());
            }

            Console.Read();
        }
    }
}