using System;
using System.Collections.Generic;

namespace ReflectionTask
{
    public static class ListUtility
    {
        public static List<T> CreateList<T>()
        {
            var list = new List<T>();
            object o = Activator.CreateInstance<T>();
            for (var i = 0; i < list.Count; i++)
            {
                list.Add((T)o);
            }
            return list;
        }
    }
}