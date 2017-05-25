using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.Practices.Unity;
using Repository;
using ServiceModels;

namespace MyBestAppConsoleApplication1
{
    class Program1
    {
        static void Main(string[] args)
        {
            var unity = UnityConfig.Initialise();
            var program = unity.Resolve<Program2_Class>();
            program.Run();
        }
    }

    class Program2_Class
    {
        private readonly CustomerReportServiceInterface _customerReportServiceInterface;
        public readonly CustomerDao _customerDao;

        public Program2_Class(CustomerReportServiceInterface customerReportServiceInterface)
        {
            _customerReportServiceInterface = customerReportServiceInterface;
            _customerDao = new CustomerDao();
        }
        public void Run()
        {
            List<ReportViewModel> cr;
            Task<List<Customer>> c1;
            var flag = 1;
            try
            {
                c1 = _customerReportServiceInterface.GetAllCustomersAsync();
                Console.WriteLine("Customers...");
                c1.Result.ForEach(c =>
                {
                    Console.WriteLine(c.Name);
                });

                cr = _customerReportServiceInterface.GetAllCustomerReportsAsync().Result;


                Console.WriteLine(Constants.CustomerReports);
                foreach (var model in cr)
                {
                    Console.WriteLine("Customer: {1}, Report Data: {0}", model.ReportData, model.Customer.Name);
                }

                #region Emulate processing

                var reportFromClientCopy = new ReportViewModel[cr.Count];
                cr.CopyTo(reportFromClientCopy);
                var reportFromClient = reportFromClientCopy.ToList();

                reportFromClient.ForEach(report =>
                {
                    if (report.Id == 1)
                    {
                        report.ReportData = "New report data";
                    }
                });

                #endregion Emulate processing

                Console.WriteLine("Result: {0}",_customerReportServiceInterface.UpdateReportDataAsync(new List<ReportViewModel>()).Result);
                Console.WriteLine("Result: {0}", _customerReportServiceInterface.UpdateReportDataAsync(reportFromClient).Result);

                Console.WriteLine("Customer Reports");

                cr = _customerReportServiceInterface.GetAllCustomerReportsAsync().Result;
                foreach (var model in cr)
                {
                    Console.WriteLine("Customer: {1}, Report Data: {0}", model.ReportData, model.Customer.Name);
                }

                Console.WriteLine("Specific reports...");
                Console.WriteLine("Specific report 1");
                var specificReport = _customerReportServiceInterface.GetReportByCust_Id(1);
                Console.WriteLine("Customer: {1}, Report Data: {0}", specificReport.Result.ReportData, specificReport.Result.Customer.Name);
                Console.WriteLine("Specific report 2");
                var specificReport2 = _customerReportServiceInterface.GetReportByCust_Id(2);
                Console.WriteLine("Customer: {1}, Report Data: {0}", specificReport2.Result.ReportData, specificReport2.Result.Customer.Name);


                if (HasReportChanged(specificReport.Result, false) > 0)
                {
                    Console.WriteLine("Report for {0} has been changed", specificReport.Result.Customer.Name);
                }
                else if(HasReportChanged(specificReport.Result, false) == 0)
                {
                    Console.WriteLine("Report for {0} has not been changed", specificReport.Result.Customer.Name);
                }
                else
                {
                    Console.WriteLine("{1} Report for {0} was skipped", specificReport.Result.Customer.Name, "Checking");
                }

                if (HasReportChanged(specificReport2.Result, false) > 0)
                {
                    Console.WriteLine("Report for {0} has been changed", specificReport2.Result.Customer.Name);
                }
                else if (HasReportChanged(specificReport2.Result, false) == 0)
                {
                    Console.WriteLine("Report for {0} has not been changed", specificReport2.Result.Customer.Name);
                }
                else
                {
                    Console.WriteLine("{1} Report for {0} was skipped", specificReport2.Result.Customer.Name, "Checking");
                }

                var someNewReport3 = new ReportViewModel
                {
                    Customer = new CustomerViewModel {Name = "Some fake customer"}
                };
                if (HasReportChanged(someNewReport3, true) > 0)
                {
                    Console.WriteLine("Report for {0} has been changed", someNewReport3.Customer.Name);
                }
                else if (HasReportChanged(specificReport2.Result, true) == 0)
                {
                    Console.WriteLine("Report for {0} has not been changed", someNewReport3.Customer.Name);
                }
                else
                {
                    Console.WriteLine("{1} Report for {0} was skipped", someNewReport3.Customer.Name, "Checking");
                }

                flag = -1;
            }
            catch (Exception e)
            {
                flag = 0;
                Console.WriteLine("Smth has happened: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine(Constants.Done);
   
            }

            if (flag < 0)
            {
                Console.WriteLine("processing finished without excetions");
            }
            else if (flag == 0)
            {
                Console.WriteLine("processing finished with exceptions");
            }
            else
            {
                Console.WriteLine("some other unpredictable result");
            }

            _customerDao._customer1.CreatedUtc = null;
            _customerDao._customer1.Name = "Some fake customer 1";
            c1 = _customerDao.GetAllCustomers();
            Console.WriteLine("Customers...");
            c1.Result.ForEach(c =>
            {
                c.CreatedUtc = DateTime.Now;
                Console.WriteLine("Name: {0}, Date of creation:{1:U}",c.Name, c.CreatedUtc);
            });

            Console.WriteLine("Finished");
            Console.Read();
        }

        public short HasReportChanged(ReportViewModel report, bool skipChecking)
        {
            if(!skipChecking)
                if (report.UpdatedUtc != null){return 1;}
                else{return 0;}
            else
            {
                return -1;
            }
        }
    }
}
