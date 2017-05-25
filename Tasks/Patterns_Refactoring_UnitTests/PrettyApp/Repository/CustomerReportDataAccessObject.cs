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
    public class CustomerReportDataAccessObject : ICusomerReportDao
    {
        private readonly ICustomerDao _customerDao;

        #region DB-emulated Data

        private readonly List<Report> _reportList;

        public CustomerReportDataAccessObject()
        {
            _customerDao = new CustomerDao();
            var report1 = new Report
            {
                Id = 1,
                CustomerId = 1,
                ReportData = "Some old report1 data",
                CreatedUtc = DateTime.UtcNow
            };
            var report2 = new Report
            {
                Id = 2,
                CustomerId = 2,
                ReportData = "Some old report2 data",
                CreatedUtc = DateTime.UtcNow
            };
            _reportList = new List<Report> {report1, report2};
        }

        #endregion

        private readonly Report _report3;

        public async Task<List<Report>> GetAllCustomerReportsAsync()
        {
            var customerList = await _customerDao.GetAllCustomers();
            var newList = _reportList.Join(customerList, report => report.CustomerId, customer => customer.Id, (report, customer) => new Report
            {Id = report.Id,Customer = customer,CustomerId = report.CustomerId,ReportData = report.ReportData,CreatedUtc = report.CreatedUtc,UpdatedUtc = report.UpdatedUtc}).ToList();
            return newList;
        }

        public async Task<Report> GetReportByCustomerId(int customerId)
        {
            var reports = await GetAllCustomerReportsAsync();
            return reports.Select(r=>r).Where(report => report.CustomerId == customerId).Single();
        }

        public async Task<string> UpdateReportDataAsync(IEnumerable<Report> reports, bool flag)
        {
            Task<List<Report>> getOld = GetAllCustomerReportsAsync();
            List<Report> getOldResult = getOld.Result;

            if (flag)
            {
                foreach (var report in reports)
                {
                    foreach (var oldResult in _reportList)
                    {
                        if (oldResult.Equals(report))
                        {
                            oldResult.ReportData = oldResult.ReportData;
                        }
                        else
                        {
                            if (oldResult.Id == report.Id)
                            {
                                if (oldResult.ReportData != report.ReportData)
                                {
                                    oldResult.ReportData = report.ReportData;
                                    oldResult.UpdatedUtc = DateTime.Now;
                                    report.UpdatedUtc = DateTime.Now;
                                }

                            }
                        }
                    }

                }
            }
            else
            {
                return "List was empty";
            }


            return "List updated";;
        }

        public Task DeleteReportDataAsync(Report report)
        {
            throw new NotImplementedException();
        }

        public Task InsertReportDataAsync(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
