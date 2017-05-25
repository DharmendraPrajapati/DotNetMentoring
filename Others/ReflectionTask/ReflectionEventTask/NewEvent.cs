using System;

namespace ReflectionEventTask
{
    //public delegate string NewEventEventHandler(object sender, EventArgs args);
    public class NewEvent
    {
        public event EventHandler<EventArgs> NewEventEventHandled;

        public string TestMethod(object sender, EventArgs args)
        {
            return "Hello from Event";
        }

        public void InvokeEvent(object sender, EventArgs args)
        {
            NewEventEventHandled?.Invoke(this, args);
        }
    }
}