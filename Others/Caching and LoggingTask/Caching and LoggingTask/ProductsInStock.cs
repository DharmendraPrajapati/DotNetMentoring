using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Caching;

namespace CachingAndLoggingTask
{
    public class ProductsInStock
    {
        private const string CacheKey = "productsInStock";
        private readonly ObjectCache _objectCache;
        
        public ProductsInStock()
        {
            _objectCache = MemoryCache.Default;
           

        }

        public IEnumerable<Product> GetAllProducts()
        {
            using(var eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);


                if (_objectCache.Contains(CacheKey))
                {
                    eventLog.WriteEntry("Products from cache");
                    return (IEnumerable<Product>)_objectCache.Get(CacheKey);
                }
                var products = DataSource.GetAllProducts();
                var cacheItemPolicy = new CacheItemPolicy {AbsoluteExpiration = DateTime.Now.AddHours(1)};
                _objectCache.Add(CacheKey, products, cacheItemPolicy);
                return products;
            }
        }
    }
}