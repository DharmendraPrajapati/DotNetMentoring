using System;

namespace ReflectionEventTask
{
    internal class Program
    {
        private static void Main()
        {
            var newEvent = new NewEvent();
            var type = typeof(NewEvent);
            var eventInfo = type.GetEvent("NewEventEventHandled");
            var methodInfo = type.GetMethod("TestMethod");
            var eventHandler = Delegate.CreateDelegate(eventInfo.EventHandlerType, newEvent, methodInfo);
            eventInfo.AddEventHandler(newEvent, eventHandler);
            newEvent.TestMethod(newEvent, EventArgs.Empty);
            Console.WriteLine(eventInfo.Name);
            Console.ReadLine();
        }
    }
}