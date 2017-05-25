using System.Collections;
using System.Collections.Generic;
using CollectionsAndGenericsTask_1.Interfaces;
//TODO: Keep different classes in difefren files
namespace CollectionsAndGenericsTask_1.Models
{
    public class MyCollection<T> : IEnumerable<T>, IMyCollection<T>
    {
        private readonly T[] _myCollection;
        private int _currentPossition;

        public MyCollection(int capacity)
        {
            _currentPossition = 0;
            _myCollection = new T[capacity];
        }

        public MyCollection(T[] myCollection)
        {
            _myCollection = myCollection;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Person<T>>) GetEnumerator();
        }

        public T[] Add(T obj)
        {
            _myCollection[_currentPossition] = obj;
            _currentPossition++;
            return _myCollection;
        }

        public T[] AddRange(T[] objs)
        {
            foreach (var obj in objs)
            {
                Add(obj);
            }
            return _myCollection;
        }

        public T[] Remove(T obj)
        {
            var value1 = obj;
            for (var i = 0; i < _myCollection.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(value1, _myCollection[i]))
                {
                    _myCollection[i] = default(T);
                }
            }
            _currentPossition--;
            return _myCollection;
        }
        public T[] RemoveAt(int index)
        {
            _myCollection[index] = default(T);
            _currentPossition--;
            return _myCollection;
        }

        public MyCollectionEnum<T> GetEnumerator()
        {
            return new MyCollectionEnum<T>(_myCollection);
        }
    }

    public class MyCollectionEnum<T> : IEnumerator<T>
    {
        private T[] _myCollection;
        private int _position;

        public MyCollectionEnum(T[] myCollection1)
        {
            _myCollection = myCollection1;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _myCollection = null;
            _position = -1;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _myCollection.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current => _myCollection[_position];
    }
}