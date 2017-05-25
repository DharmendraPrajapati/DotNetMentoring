using System.Collections.Generic;
using System.Threading.Tasks;
using DataModels;

namespace Data.Contracts
{
    public interface ICusomerReportDao
    {
        Task<List<Report>> GetAllCustomerReportsAsync();
        Task<Report> GetReportByCustomerId(int customerId);

        Task<string> UpdateReportDataAsync(IEnumerable<Report> reports, bool isListNotEmpty);

        Task DeleteReportDataAsync(Report report);

        Task InsertReportDataAsync(Report report);
    }
}