
using LogTask.ServiceClass;

namespace LogTask
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            var service = new DataService();
            service.GetAllCustomers();
            service.GetAllProducts();
        }
    }
}
