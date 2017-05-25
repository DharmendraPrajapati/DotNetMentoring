using System.Collections.Generic;

namespace ReflectionTask
{
    internal class GenericClass<T>
    {
        private readonly IList<T> _listCollection;

        public GenericClass()
        {
            _listCollection = new List<T>();
        }
        public void SetValue(T val)
        {
            _listCollection.Add((T)val);
        }
        public IList<T> GetList()
        {
            return _listCollection;
        }
    }
}
