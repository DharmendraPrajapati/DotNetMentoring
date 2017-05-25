using System.Collections;
using System.Collections.Generic;

namespace GenericsTask1
{
    public class GenericIEnum<T> : IEnumerable<T>
    {
        private readonly T[] _myItems;
        //TODO: setting value by default is redundant: your type is not nullable.
        private int _index=0;

        public GenericIEnum(int capacity)
        {
            
            _myItems = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var t in _myItems)
                //TODO: don't forget about braces
                yield return t;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(object item)
        {
            _myItems[_index] = (T) item;
            _index++;
        }
    }
}