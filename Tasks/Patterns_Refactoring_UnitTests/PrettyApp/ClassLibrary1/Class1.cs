using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contracts;
using DataModels;

using ServiceModels;

namespace ClassLibrary1
{
    public class MyNewService1: CustomerReportServiceInterface
    {
        private readonly ICustomerDao _cusomerDao;

        private readonly ICusomerReportDao _cusomerReportDao;

        public MyNewService1(ICustomerDao cusomerDao, ICusomerReportDao cusomerReportDao)
        {
            _cusomerDao = cusomerDao;
            _cusomerReportDao = cusomerReportDao;

        }

        /// <summary>
        /// Returns customer data, ordered by id and name  by desc
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = await _cusomerDao.GetAllCustomers();
                customers.OrderBy(r=>r.Name).OrderByDescending(c => c.Id);
            return customers;
        }

        public async Task<List<ReportViewModel>> GetAllCustomerReportsAsync()
        {
           var reports = await _cusomerReportDao.GetAllCustomerReportsAsync().ConfigureAwait(false);

             return reports.Select(r=> new ReportViewModel{Customer=new CustomerViewModel{Id=r.Customer.Id,Name=r.Customer.Name},Id=r.Id,ReportData=r.ReportData, UpdatedUtc = r.UpdatedUtc }).ToArray().ToList();

        }

        public async Task<ReportViewModel> GetReportByCust_Id(int id)
        {
            var r = await _cusomerReportDao.GetReportByCustomerId(id);

        return new ReportViewModel
        {
            Customer = new CustomerViewModel { Id = r.Customer.Id, Name = r.Customer.Name },Id = r.Id,ReportData = r.ReportData,
            UpdatedUtc = r.UpdatedUtc
        };
        }

        public async Task<string> UpdateReportDataAsync(List<ReportViewModel> reports)
        {
            Console.WriteLine("Updating");

            string returningResult = String.Empty;
            if (reports.Count > 0)
            {
                var result = await _cusomerReportDao.UpdateReportDataAsync(reports.Select(report => new Report { Customer = new Customer { Id = report.Customer.Id, Name = report.Customer.Name }, Id = report.Id, ReportData = report.ReportData }), true);
                returningResult = result;
            }
                
            else
            {
                var result = await _cusomerReportDao.UpdateReportDataAsync(reports.Select(report => new Report { Customer = new Customer { Id = report.Customer.Id, Name = report.Customer.Name }, Id = report.Id, ReportData = report.ReportData }), false);
                returningResult = result;
            }

            return returningResult;

        }

        public Task DeleteReportDataAsync(Report report)
        {
            throw new NotImplementedException();
        }

        public Task InsertReportDataAsync(Report report)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(CustomerViewModel report)
        {
            throw new NotImplementedException();
        }

        public Task InsertCustomerAsync(CustomerViewModel report)
        {
            throw new NotImplementedException();
        }
    }


}
