using System;
using System.Globalization;
using System.Linq;
using Task.Data;

namespace Task
{
    public class LinqSamples
    {
        private readonly DataSource _dataSource = new DataSource();

        public void LinqTask1()
        {
            //TODO: There could be a input parameter here to accept that value of X
            //TODO: In this implementation it is fixed to 2500
            Console.WriteLine(@"Customer with whose total turnover (the sum of all orders) exceeds a certain amount of 2500");

            var customers = _dataSource.Customers.Where(c => c.Orders.Sum(a => a.Total) > 2500);

            foreach (var p in customers)
            {
                Console.WriteLine(@"Customer -> " + p.CustomerId);
            }
        }
        public void LinqTask2()
        {
            Console.WriteLine(@"List of suppliers in that same country and the same city ** with Group by");
            //TODO: This sql style of writing LINQ is old now
            //TODO: Prefer and use Lambda style of writing LINQ
            var customers = from c in _dataSource.Customers
                            join s in _dataSource.Suppliers on new
                            { c.Country, c.City } equals new
                            {
                                s.Country,
                                s.City
                            }
                            group new { s.SupplierName } by new
                            {

                                s.Country,
                                s.City,
                                c.CustomerId
                            }
                into newCustomer
                            select new
                            {
                                Customer = newCustomer.Key.CustomerId,
                                Supplier = string.Join(",", newCustomer.Select(a => a.SupplierName).ToList())
                            };

            customers.ToList().ForEach((p) =>
            {
                Console.WriteLine(@"Customer -> " + p.Customer + @" Suppliers " + p.Supplier);
            });
        }

        public void LinqTak2WithoutGroupBy()
        {
            //TODO: This sql style of writing LINQ is old now
            //TODO: Prefer and use Lambda style of writing LINQ
            var customers = from c in _dataSource.Customers
                            select new
                            {
                                CustomerName = c.CustomerId,
                                SupplierInfo =
                                _dataSource.Suppliers.Where(a => a.Country == c.Country && a.City == c.City).Select(a => a.SupplierName)
                                    .ToList()

                            };

            Console.WriteLine(@"list of suppliers in that same country and the same city ** Without Group by");

            customers.ToList().ForEach((p) =>
            {
                if (p.SupplierInfo.Any())
                {
                    Console.WriteLine(@"Customer -> " + p.CustomerName + @" Suppliers " + string.Join(",", p.SupplierInfo));
                }
            });
        }
        public void LinqTask3()
        {
            var customers = _dataSource.Customers.Where(c => c != null && c.Orders.Count() > 5);

            Console.WriteLine(@"All customers who have orders that exceed the amount of 5");

            customers.ToList().ForEach((p) =>
            {
                Console.WriteLine(@"Customer -> " + p.CustomerId);
            });
        }
        public void LinqTask4()
        {
            Console.WriteLine(@"List of customers indicating which month of the year they became clients");

            _dataSource.Customers.ForEach((a) =>
            {
                if (a.Orders.Any())
                {
                    Console.WriteLine(@"Customer -> " + a.CustomerId + @" First Order date : " +
                                      a.Orders.Max(o => o.OrderDate).ToString("MMM", CultureInfo.InvariantCulture));
                }
            });
        }
        public void LinqTask5()
        {
            Console.WriteLine(@"List of customers indicating which month of the year they became clients sorted by year, month, client turnover (from maximum to minimum) and customer name ");

            var customers = from c in _dataSource.Customers
                            where c.Orders.Length > 0
                            select new
                            {
                                OrderDate = c.Orders.Max(a => a.OrderDate),
                                Customer = c.CustomerId,
                                TurnOver = c.Orders.Sum(o => o.Total)
                            };

            var filteredResult = customers.OrderBy(a => a.OrderDate.Year)
                .ThenBy(a => a.OrderDate.Month)
                .ThenByDescending(a => a.TurnOver)
                .ThenBy(a => a.Customer).ToList();

            filteredResult.ForEach((customer) =>
            {
                Console.WriteLine($@"Year {customer.OrderDate.Year} / 
                                    {customer.OrderDate.ToString("MMM", CultureInfo.InvariantCulture)} 
                                    With turnover {customer.TurnOver} Customer {customer.Customer}");
            });
        }
        public void LinqTask6()
        {
            Console.WriteLine(@"All customers who have a non-numeric code or are not filled in the region or the phone does not have an operator code");
            var region = new[] {"BC"};

            var filterCustomers = _dataSource.Customers.Where(a => 
                                    a.PostalCode != null && 
                                        (!a.PostalCode.All(char.IsDigit) || 
                                          region.Contains(a.Region) || 
                                          !a.Phone.StartsWith("("))).ToList();
            filterCustomers.ForEach((a) =>
            {
                Console.WriteLine(a.CustomerId);
            });
        }
        public void LinqTask7()
        {
            Console.WriteLine(@"Get Customer with order (the sum of all orders) exceeds a certain amount of 2500");
            var range = new decimal[] { 35, 50 };
            //TODO: This could be simplified
            var groupProd = _dataSource.Products.GroupBy(x => range.FirstOrDefault(r => r > x.UnitPrice)).ToList();
            groupProd.ForEach((a) =>
            {
                if (a.Key == range[0])
                {
                    Console.WriteLine(@"Cheap  :");
                }
                else if (a.Key == range[1])
                {
                    Console.WriteLine(@"Average");
                }
                else
                {
                    Console.WriteLine(@"Expensive:");
                }
                a.ToList().ForEach(p =>
                {
                    Console.WriteLine($@"Price : {p.UnitPrice}");
                });
            });
        }
    }
}