using GenericsTask1.DataRepositories;
using GenericsTask1.GenericRepository;
using GenericsTask1.Models;
using System.Collections.Generic;
using System.Linq;

namespace GenericsTask1.Services
{
    public class ProductRepositoryService : IRepository<Product, int>
    {
        private readonly List<Product> _allProducts;

        public ProductRepositoryService()
        {
            _allProducts = ProductRepo.GetAllProducts().ToList();
        }

        public IEnumerable<Product> GetItems()
        {
            return _allProducts;
        }

        public Product GetItem(int key)
        {
            return _allProducts.FirstOrDefault(product => product.Id == key);
        }

        public void Add(Product item)
        {
            _allProducts.Add(item);
        }

        public void AddRange(IEnumerable<Product> items)
        {
            _allProducts.AddRange(items);
        }

        public void Update(int tKey, Product item)
        {
            var productToUpdate = GetItem(tKey);
            if(productToUpdate == null)
            {
                return;
            }
            productToUpdate.Description = item.Description;
            productToUpdate.MaufacturedDate = item.MaufacturedDate;
            productToUpdate.Rating = item.Rating;
        }

        public void Delete(int tKey)
        {
            var productToRemove = GetItem(tKey);
            if(productToRemove == null)
            {
                return;
            }
            _allProducts.Remove(productToRemove);
        }

        public int Count()
        {
            return _allProducts.Count;
        }
    }
}