using GenericsTask1.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsTask1
{
    internal class Products : IEnumerable
    {
        private readonly List<Product> _products;

        public Products(List<Product> products)
        {
            _products = products;

            for (int i = 0; i < _products.Count; i++)
            {
                _products[i] = products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach(var product in _products)
            {
                yield return product;
            }
            
            
        }

        public ProductEnumeration GetEnumerator()
        {
            return new ProductEnumeration(_products);
        }
    }

    public class ProductEnumeration : IEnumerator
    {
        public List<Product> Products;
        private int _position = -1;

        public ProductEnumeration(List<Product> products)
        {
            Products = products;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < Products.Count);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Product Current
        {
            get
            {
                try
                {
                    return Products[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}