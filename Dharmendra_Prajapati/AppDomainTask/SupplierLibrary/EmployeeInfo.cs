using System;
namespace SupplierLibrary
{
    public class EmployeeInfo :MarshalByRefObject,IEmployeeInfo
    {
        private readonly Employee _emp;
        public string DomainName => AppDomain.CurrentDomain.FriendlyName;

        public EmployeeInfo()
        {
            _emp = new Employee() { EmployeeAddress = "India", EmployeeName = "Abc", EmployeeId = 1001};
        }
        public EmployeeInfo(Object obj)
        {

            _emp = obj as Employee;
        }
        public Employee GetSupplier()
        {
            return _emp;
        }

        public string GetSupplierName()
        {
            return _emp.EmployeeName;
        }
        public string GetSupplierAddress()
        {
            return _emp.EmployeeAddress;
        }
        public override string ToString()
        {
            return $"Employee Id: {_emp.EmployeeId} Name {_emp.EmployeeName} Address {_emp.EmployeeAddress}";
        }
    }
}
