using System;

namespace ExceptionHandlingTask
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            var stringToInt = new StringToInt();
            var no = stringToInt.StringToIntConverter("123");
            Console.WriteLine("No {0} Type {1}", no, no.GetType());
            var stackHandling = new StackHandling();
            StackHandling.FillData();
            StackHandling.TransmitData();
            //StackHandling.PushIntoBackUpStack();
            Console.Read();
        }
    }
}