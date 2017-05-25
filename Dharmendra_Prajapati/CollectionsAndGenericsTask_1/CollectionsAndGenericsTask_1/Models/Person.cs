namespace CollectionsAndGenericsTask_1.Models
{
    public class Person<T>
    {
        public string PersonId { get; set; }
        public int Age { get; set; }
        public T Type { get; set; }

        internal string GetClassType()
        {
            return typeof(T).Namespace;
        }
    }
}
