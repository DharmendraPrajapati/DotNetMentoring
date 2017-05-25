using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Data.Contracts;
using DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceModels;

namespace UnitTestProject1
{
    /// <summary>
    ///     Summary description for CustomerReportServiceTest
    /// </summary>
    [TestClass]
    public class CustomerReportServiceTest
    {
        private Mock<ICusomerReportDao> _cusomerReportDaoMock;

        private Mock<ICustomerDao> _customerDaoMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _cusomerReportDaoMock = new Mock<ICusomerReportDao>();
            _customerDaoMock = new Mock<ICustomerDao>();
        }

        private CustomerReportServiceInterface CreateCustomerReportService()
        {
            return new MyNewService1(_customerDaoMock.Object,
                _cusomerReportDaoMock.Object);
        }

        private List<Report> CreateReportList()
        {
            return new List<Report>
            {
                new Report
                {
                    Id = 1,
                    Customer = new Customer(),
                    ReportData = "Expected Data"
                }
            };
        }

        private ICollection CreateReportViewModelList(IEnumerable<Report> reports)
        {
            return
                reports.Select(
                    r =>
                        new ReportViewModel
                        {
                            Customer = new CustomerViewModel {Id = r.Customer.Id, Name = r.Customer.Name},
                            Id = r.Id,
                            ReportData = r.ReportData,
                            UpdatedUtc = r.UpdatedUtc
                        }).ToList();
        }

        [TestMethod]
        public async Task GetAllCustomerReportsAsyncReturnsNonNullCollection()
        {
            var service = CreateCustomerReportService();
            var reportList = CreateReportList();

            _cusomerReportDaoMock.Setup(svc => svc.GetAllCustomerReportsAsync())
                .Returns(() => Task.Run(() => reportList));

            var actual = await service.GetAllCustomerReportsAsync();

            CollectionAssert.AllItemsAreNotNull(actual);
        }

        [TestMethod]
        public async Task GetAllCustomerReportsAsyncReturnsExpectedData()
        {
            var service = CreateCustomerReportService();
            var reportList = CreateReportList();
            var reportViewModelList = CreateReportViewModelList(reportList);

            _cusomerReportDaoMock.Setup(svc => svc.GetAllCustomerReportsAsync())
                .Returns(() => Task.Run(() => reportList));

            var actual = await service.GetAllCustomerReportsAsync();

            var comparer = new ReportViewModelComparer();
            CollectionAssert.AreEqual(reportViewModelList, actual, comparer);
        }
    }
}