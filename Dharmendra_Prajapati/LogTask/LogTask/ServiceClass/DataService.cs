using System.Collections.Generic;
using System.Runtime.Caching;
using LogTask.DataAccess_Class;
using LogTask.Logger_Class;

namespace LogTask.ServiceClass
{
    public class DataService
    {
        private readonly MemoryCache _cache;
        private readonly DataInitializer _dataSource;
        private readonly LogHelper _logHelper;
        private const string _customerKey = "Customer"; 
        private const string _productKey = "Product";
        public DataService()
        {
            _cache = MemoryCache.Default;
            _logHelper = new LogHelper();
            _dataSource = new DataInitializer();
        }
        public IList<Customer> GetAllCustomers()
        {
            var result = GetCacheValue(_customerKey);
            if (result != null)
            {
                _logHelper.LogInfo("Data Retrieve from Cache");
            }
            else
            {
                _logHelper.LogInfo("Data Retrieve from Data Service");
                SetCacheValue(_customerKey, _dataSource.Customers);
            }
            return _dataSource.Customers;
        }

        public IList<Product> GetAllProducts()
        {
            var result = GetCacheValue(_productKey);
            if (result != null)
            {
                _logHelper.LogInfo("Data Retrieve from Cache");
            }
            else
            {
                _logHelper.LogInfo("Data Retrieve from Data Service");
                SetCacheValue(_productKey, _dataSource.Products);
            }
            return _dataSource.Products;
        }

        private object GetCacheValue(string key)
        {
            if(_cache.Get(key)==null)
            {
                _logHelper.LogError($"Cache Does not contain {key} data");
            }
            return _cache.Get(key);
        }

        private void SetCacheValue<T>(string key, IList<T> data)
        {
            //TODO: Try to set the expiration as well here
            _cache.Add(key, data,new CacheItemPolicy());
        }
    }
}
