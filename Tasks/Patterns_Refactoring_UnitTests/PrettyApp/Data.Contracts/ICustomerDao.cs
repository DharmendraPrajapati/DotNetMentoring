using System.Collections.Generic;
using System.Threading.Tasks;
using DataModels;
using ServiceModels;

namespace Data.Contracts
{
    public interface ICustomerDao
    {
        Task<List<Customer>> GetAllCustomers();
    }
}