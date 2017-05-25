using System;
using System.Reflection;

namespace AppDomainTask
{
    internal class Program
    {
        public static void Main()
        {
            var supDomain = AppDomain.CreateDomain("Emp_1");
            try
            {
                var typeObj = typeof(SupplierLibrary.EmployeeInfo);
                var on = Assembly.GetAssembly(typeObj);
                supDomain.Load(on.FullName);
                
                var empObj = (SupplierLibrary.EmployeeInfo)supDomain.CreateInstanceAndUnwrap(typeObj.Assembly.FullName, typeObj.FullName);

                Console.WriteLine(empObj.ToString());
                Console.WriteLine(empObj.DomainName);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                AppDomain.Unload(supDomain);
            }
        }
    }
}
