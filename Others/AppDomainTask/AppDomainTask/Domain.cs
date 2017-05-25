using System;

namespace AppDomainTask
{
    public class Domain : MarshalByRefObject
    {
        public void Main(string[] args)
        {
            Console.WriteLine("AppDomain Other Domain FriendlyName: {0}", AppDomain.CurrentDomain.FriendlyName);
            foreach(var item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
}