using System;
namespace ReflectionTask.EventClasses
{
    public class EventClass
    {
        public delegate void PrintMessage();

        public event PrintMessage PrintEvent;
        public EventClass()
        {
            PrintEvent = PrintText;
        }

        private static void PrintText()
        {
            Console.WriteLine("Without Reflaction");
        }

        public void FireEvent()
        {
            PrintEvent?.Invoke();
        }
        public virtual void OnPrintEvent()
        {
            PrintEvent?.Invoke();
        }
    }
}
