using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Task.Data;
using Task.Helpers.ResizerApp.Helpers;

namespace Task
{
    public class LinqSamples
    {
        private readonly IList<Customer> _customers;
        private readonly DataSource _dataSource;
        private readonly IList<Product> _products;
        private readonly IList<Supplier> _suppliers;

        public LinqSamples()
        {
            _dataSource = new DataSource();
            _customers = _dataSource.Customers;
            _suppliers = _dataSource.Suppliers;
            _products = _dataSource.Products;
        }

        public void Linq1()
        {
            MessageHelper.InfoMessage("Linq1. Numbers < 5:");
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            var lowNums = from num in numbers where num < 5 select num;
            foreach(var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        public void Linq2()
        {
            MessageHelper.InfoMessage("Linq2. UnitsInStock count is 20");
            var products = from p in _dataSource.Products where p.UnitsInStock == 20 select p;
            foreach(var p in products)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        public void Linq3()
        {
            MessageHelper.InfoMessage("Linq3. UnitPrice less than 20M");
            var products = _dataSource.Products.Where(p => p.UnitPrice < 20.000M);
            foreach(var p in products)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        public void TotalTurnover()
        {
            MessageHelper.InfoMessage("Total Turnover");
            var customers =
                    _dataSource.Customers.Where(c => c.Orders.Sum(o => o.Total) > 1000)
                               .Select(
                                       customer =>
                                           new
                                           {
                                               Id = customer.CustomerId,
                                               Total = customer.Orders.Sum(s => s.Total)
                                           })
                               .ToList();
            customers.ForEach(customer =>
                              {
                                  MessageHelper.InfoMessage(customer.Id);
                                  MessageHelper.InfoMessage(customer.Total.ToString(CultureInfo.InvariantCulture));
                              });
        }

        public void ListOfSuppliers()
        {
            MessageHelper.InfoMessage("List of suppliers in that same country and the same city");
            var customers =
                    _customers.Join(_suppliers,
                                    customer => customer.Country,
                                    supplier => supplier.Country,
                                    (customer, supplier) => new {Customer = customer, Supplier = supplier})
                              .Where(cS => cS.Supplier.City == cS.Customer.City);
            customers.ToList().ForEach(customer =>
                                       {
                                           MessageHelper.InfoMessage(customer.Customer.CustomerId);
                                           MessageHelper.InfoMessage(customer.Supplier.City);
                                       });
        }

        public void OrdersExceedXAmount()
        {
            MessageHelper.InfoMessage("All customers who have orders that exceed the amount of X");
            var customers =
                    _customers.Where(customer => customer.Orders.Any(order => order.Total > 15000))
                              .Select(c => new {c.CustomerId, c.City, c.Address})
                              .ToList();
            customers.ForEach(customer =>
                              {
                                  MessageHelper.InfoMessage(customer.CustomerId);
                                  MessageHelper.InfoMessage(customer.City);
                                  MessageHelper.InfoMessage(customer.Address);
                              });
        }

        public void BecameClientDate()
        {
            MessageHelper.InfoMessage("Issue a list of customers indicating which month of the year they became clients");
            var customers =
                    _customers.Where(cWithOrders => cWithOrders.Orders.Any())
                              .Select(
                                      customer =>
                                          new
                                          {
                                              Id = customer.CustomerId,
                                              Toatl = customer.Orders.Sum(a => a.Total),
                                              OrderDate =
                                              customer.Orders.Select(cDate => cDate.OrderDate).FirstOrDefault()
                                          })
                              .ToList();
            customers.ForEach(customer =>
                              {
                                  MessageHelper.InfoMessage(customer.Id);
                                  MessageHelper.InfoMessage(customer.OrderDate.ToShortDateString());
                              });
        }

        public void SortedListOfCustomers()
        {
            MessageHelper.InfoMessage(
                                      "list sorted by year, month, client turnover (from maximum to minimum) and customer name");
            var customers =
                    _customers.Where(cWithOrders => cWithOrders.Orders.Any())
                              .OrderBy(_ => _.Orders.Sum(s => s.Total))
                              .ThenBy(d => d.Orders.Select(dt => dt.OrderDate))
                              .ThenBy(c => c.CustomerId)
                              .Select(c => c)
                              .ToList();
            customers.ForEach(customer =>
                              {
                                  MessageHelper.InfoMessage(customer.CustomerId);
                                  MessageHelper.InfoMessage(customer.Orders.Sum(s => s.Total).ToString());
                              });
        }

        public void CustomersWithNoCodes()
        {
            MessageHelper.InfoMessage(
                                      "Specify all customers who have a non-numeric code or are not filled in the region or the phone does not have an operator code");
            int i;
            var customers =
                    _dataSource.Customers.Where(
                                                customer =>
                                                    !int.TryParse(customer.PostalCode, out i) ||
                                                    ( customer.Region == null ) ||
                                                    ( customer.Phone.IndexOf("(", 0, 0, StringComparison.Ordinal) == -1 ))
                               .ToList();
            customers.ForEach(customer => { MessageHelper.InfoMessage(customer.CustomerId); });
        }

        public void GroupProductsCheapAverageExpensive()
        {
            MessageHelper.InfoMessage("Group products into groups cheap, average price, expensive. ");
            var productList =
                    _dataSource.Products.GroupBy(
                                                 price =>
                                                     new
                                                     {
                                                         Group =
                                                         ( price.UnitPrice > 0 ) && ( price.UnitPrice < 50 )
                                                             ? "Cheap"
                                                             : ( price.UnitPrice >= 50 ) && ( price.UnitPrice < 100 )
                                                                 ? "Average"
                                                                 : "Expensive"
                                                     })
                               .Select(x => new {x.Key.Group, Count = x.Count()})
                               .ToList();
            productList.ForEach(product => MessageHelper.InfoMessage(product.Group + @" - " + product.Count));
        }
    }
}