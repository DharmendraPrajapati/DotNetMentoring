using System;

namespace Task
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sample  = new LinqSamples();

            sample.LinqTask1();
            sample.LinqTask2();
            sample.LinqTak2WithoutGroupBy();
            sample.LinqTask3();
            sample.LinqTask4();
            sample.LinqTask5();
            sample.LinqTask7();
            sample.LinqTask6();
            Console.ReadKey();
        }
    }
}