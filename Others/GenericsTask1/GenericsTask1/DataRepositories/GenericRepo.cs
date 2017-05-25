using System.Collections.Generic;

//TODO: unused usings

namespace GenericsTask1.DataRepositories
{
    public class GenericRepo<T>
    {
        public static List<T> Items { get; set; }

        public static IEnumerable<T> GetAllItems()
        {
            return Items;
        }
    }
}