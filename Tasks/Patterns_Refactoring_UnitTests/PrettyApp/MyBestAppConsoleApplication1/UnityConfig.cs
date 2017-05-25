using ClassLibrary1;
using Data.Contracts;
using Microsoft.Practices.Unity;
using Repository;

namespace MyBestAppConsoleApplication1
{
    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            //Set dependency resolver here, if needed

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<CustomerReportServiceInterface, MyNewService1>();
            container.RegisterType<ICustomerDao, CustomerDao>();
            container.RegisterType<ICusomerReportDao, CustomerReportDataAccessObject>();

            return container;
        }
    }
}