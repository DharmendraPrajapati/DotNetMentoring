using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Data.Contracts;
using DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class TestForCheckMyCode
    {
        private readonly CustomerReportServiceInterface _customerReportServiceInterface;
        Mock<ICusomerReportDao> _cusomerReportDaoMock;

        public TestForCheckMyCode()
        {
            
        }
        public TestForCheckMyCode(CustomerReportServiceInterface customerReportServiceInterface)
        {
            _customerReportServiceInterface = customerReportServiceInterface;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _cusomerReportDaoMock = new Mock<ICusomerReportDao>();
        }

        [TestMethod]
        public async Task MyBestTestMethod1()
        {
           var reports = await _customerReportServiceInterface.GetAllCustomerReportsAsync();

            if (reports.Count > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false, "test failed");
            }
        }

        [TestMethod]
        public async Task GetAllCustomerReportsReturns()
        {
            var expected = new List<Report>();
            _cusomerReportDaoMock.Setup(dao => dao.GetAllCustomerReportsAsync())
                .Returns(() => Task.Run(()=> expected));

            var cusomerReportDao = _cusomerReportDaoMock.Object;
            var actual = await cusomerReportDao.GetAllCustomerReportsAsync();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected.First().Id, actual.First().Id);
        }
    }
}
