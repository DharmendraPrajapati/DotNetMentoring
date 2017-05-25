using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using ServiceModels;

namespace ClassLibrary1
{
    public interface CustomerReportServiceInterface
    {
        Task<List<Customer>> GetAllCustomersAsync();

        Task<List<ReportViewModel>> GetAllCustomerReportsAsync();
        Task<ReportViewModel> GetReportByCust_Id(int id);

        Task<string> UpdateReportDataAsync(List<ReportViewModel> reports);

        Task DeleteReportDataAsync(Report report);

        Task InsertReportDataAsync(Report report);

        Task DeleteCustomerAsync(CustomerViewModel report);

        Task InsertCustomerAsync(CustomerViewModel report);
    }
}
