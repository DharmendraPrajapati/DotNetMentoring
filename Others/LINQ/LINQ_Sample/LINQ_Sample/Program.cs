using System;

namespace Task
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sample = new LinqSamples();
            sample.TotalTurnover();
            sample.ListOfSuppliers();
            sample.SortedListOfCustomers();
            sample.OrdersExceedXAmount();
            sample.BecameClientDate();
            sample.CustomersWithNoCodes();
            sample.GroupProductsCheapAverageExpensive();
            Console.Read();
        }
    }
}