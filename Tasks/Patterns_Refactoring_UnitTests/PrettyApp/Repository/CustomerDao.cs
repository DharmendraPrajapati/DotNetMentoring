using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contracts;
using DataModels;
using ServiceModels;

namespace Repository
{
    public class CustomerDao: ICustomerDao
    {
        #region DB-emulated Data

        public Customer _customer1 = new Customer
        {
            Id = 1,
            Name = "Some awesome customer 1",
            Phone = "666-77-8888",
            CreatedUtc = DateTime.UtcNow
        };

        private Report _report1;
        private Report _report2;

        public CustomerDao()
        {
            _customer2 = new Customer
            {
                Id = 2,
                Name = "Some awesome customer 2",
                Phone = "11-222-3333",
                CreatedUtc = DateTime.UtcNow
            };

            _report1 = new Report
            {
                Customer = _customer1,
                ReportData = "Some old report1 data",
                CreatedUtc = DateTime.UtcNow
            };

            _report2 = new Report
            {
                Customer = _customer2,
                ReportData = "Some old report2 data",
                CreatedUtc = DateTime.UtcNow
            };
        }

        private readonly Customer _customer2;
#endregion
        public Task<List<Customer>> GetAllCustomers()
        {
            var customerList = new List<Customer>
            {
                _customer1,
                _customer2
            };

            return Task.Run(() => customerList);
        }
    }
}
