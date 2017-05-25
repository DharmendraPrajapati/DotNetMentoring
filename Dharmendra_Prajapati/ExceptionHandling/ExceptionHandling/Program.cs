using System;
using System.Collections.Generic;
using SringConverter;

namespace ExceptionHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringConvert.ConvertStringToInteger("123");
            ExecuteStackTask();
            Console.ReadLine();
        }

        private static void ExecuteStackTask()
        {
            var data = new Stack<string>();
            PushData(data);
            Console.WriteLine("Initial Data Count is :"+data.Count);
            AccessDataApi(data);
            Console.WriteLine("After reset Data Count is :" + data.Count);
        }

        private static void AccessDataApi(Stack<string> data)
        {
            var sendItems = new Stack<string>();
            
            try
            {
                for (var i = 0; i < 50; i++)
                {
                    var currentItem = data.Pop();
                    sendItems.Push(currentItem);
                    if (i != 5)
                    {
                        PrintDataAccessOnIndex(currentItem);
                    }
                    else
                    {
                        throw new Exception($"Throwing Error on {i}th Item");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception \n Message " + ex.Message);
                SetInitialStage(sendItems, data);
            }
        }

        private static void SetInitialStage(Stack<string> sendItems, Stack<string> data)
        {
            Console.WriteLine("Reseting data after Exception.");
            while (sendItems.Count>0)
            {
                data.Push((sendItems.Pop()));
            }
        }

        private static void PrintDataAccessOnIndex(string item)
        {
            Console.WriteLine("Stack Item : "+item);
        }

        private static void PushData(Stack<string> data)
        {
            for (var i = 0; i < 100; i++)
            {
                data.Push(DateTime.Now.Ticks + " */* " + i);
            }
        }
    }
}
