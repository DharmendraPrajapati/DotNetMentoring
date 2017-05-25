using System.Collections.Generic;

namespace GenericsTask1.GenericRepository
{
    public interface IRepository<T, in TKey> where T : class 
    {
        IEnumerable<T> GetItems();

        T GetItem(TKey key);

        void Add(T item);

        void AddRange(IEnumerable<T> items);

        void Update(TKey tKey, T item);

        void Delete(TKey tKey);

        int Count();
    }
}