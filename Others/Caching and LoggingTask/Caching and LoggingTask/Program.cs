using System;

namespace CachingAndLoggingTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var productsInStock = new ProductsInStock();
            var items = productsInStock.GetAllProducts();
            foreach(var product in items)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var items2 = productsInStock.GetAllProducts();
            foreach(var product in items2)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.Read();
        }
    }
}