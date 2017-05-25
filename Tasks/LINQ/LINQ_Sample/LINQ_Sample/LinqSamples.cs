using System;
using System.Diagnostics;
using System.Linq;
using Task.Data;
using Task.Helpers.ResizerApp.Helpers;

namespace Task
{
    public class LinqSamples
    {
        private readonly DataSource _dataSource = new DataSource();

        public void Linq1()
        {
            MessageHelper.InfoMessage("Linq1. Numbers < 5:");
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var lowNums =
                from num in numbers
                where num < 5
                select num;

            
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        public void Linq2()
        {
            MessageHelper.InfoMessage("Linq2. UnitsInStock count is 20");
            var products =
                from p in _dataSource.Products
                where p.UnitsInStock == 20
                select p;

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        public void Linq3()
        {
            MessageHelper.InfoMessage("Linq3. UnitPrice less than 20M");

            var products = _dataSource.Products.Where(p => p.UnitPrice < 20.000M);

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}