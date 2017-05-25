using CollectionsAndGenericsTask_1.Models;

namespace CollectionsAndGenericsTask_1.Interfaces
{
    public interface IMyCollection<T> 
    {
        T[] Add(T obj);
        T[] Remove(T obj);
        T[] RemoveAt(int index);
        MyCollectionEnum<T> GetEnumerator();
    }
}