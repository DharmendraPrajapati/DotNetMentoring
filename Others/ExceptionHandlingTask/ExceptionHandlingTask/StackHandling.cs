using System;
using System.Collections.Generic;

namespace ExceptionHandlingTask
{
    public class StackHandling
    {
        public StackHandling()
        {
            ObjectStack = new Stack<int>();
            BackUpList = new List<int>(ObjectStack.Count);
        }

        private static Stack<int> ObjectStack { get; set; }
        private static List<int> BackUpList { get; set; }

        public static void FillData()
        {
            for(var i = 0; i < 10; i++)
            {
                ObjectStack.Push(i + 1);
            }
        }

        public static void TransmitData()
        {
            var initialCount = ObjectStack.Count;
            Console.WriteLine("Initial Stack Contents Count {0}", initialCount);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine);
            try
            {
                for(var i = 0; i < initialCount; i++)
                {
                    //Simulating an Exception
                    if(i == 4)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    Console.WriteLine("Initial Value {0} at position {1}", ObjectStack.Peek(), i);
                    PushIntoBackUpStack(ObjectStack.Pop());
                }
            }
            catch(IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception);
                OnExceptionRestoreStack();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                OnExceptionRestoreStack();
            }
            finally
            {
                Console.WriteLine("Count: {0}", ObjectStack.Count);
            }
        }

        private static void PushIntoBackUpStack(int i)
        {
            BackUpList.Add(i);
            BackUpList.Sort();
        }

        private static void OnExceptionRestoreStack()
        {
            foreach(var i in BackUpList)
            {
                ObjectStack.Push(i);
            }
            var initialCount = ObjectStack.Count;
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Restored Stack Contents Count {0}", ObjectStack.Count);
            Console.WriteLine("Contents from Restored Stack");
            for(var i = 0; i < initialCount; i++)
            {
                Console.WriteLine("Restored value {0} ,  at Position {1}", ObjectStack.Pop(), i);
            }
            Console.WriteLine("Restored Stack To Initial State");
        }
    }
}