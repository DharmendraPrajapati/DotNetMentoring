using System;
using System.Collections.Generic;
using ReflectionTask.EventClasses;
using System.Reflection;

namespace ReflectionTask
{
    public class Program
    {
        public delegate void NewMessage();

        public void PrintString()
        {
            Console.WriteLine("Reflection");
        }
        public static void Main(string[] args)
        {
           var p = new Program();
            p.HookEvent();
            p.GenerateList();
        }

        public void HookEvent()
        {
            var eventObj = new EventClass();
            eventObj.OnPrintEvent();
            var typeInfo = typeof(EventClass);
            var eventClassInstance = (EventClass)Activator.CreateInstance(typeInfo);
            var printEvent = typeInfo.GetEvent("PrintEvent");
            var eventHandlerType = printEvent.EventHandlerType;

            var mthod = typeof(Program).GetMethod("PrintString", BindingFlags.Public | BindingFlags.Instance);
            var dd = Delegate.CreateDelegate(eventHandlerType, this, mthod);
            Object[] addHandlerArgs = { dd };
            var addHandler = printEvent.GetAddMethod();
            addHandler.Invoke(eventClassInstance, addHandlerArgs);
            eventClassInstance.OnPrintEvent();
        }

        public void GenerateList()
        {
            var typeObj = typeof(GenericClass<string>);
            var stringinstance = (GenericClass<string>)Activator.CreateInstance(typeObj);
            var methodInfo = typeObj.GetMethod("SetValue");
            methodInfo.Invoke(stringinstance, new object[] { "string 1" });
            methodInfo.Invoke(stringinstance, new object[] { "string 2" });
            methodInfo.Invoke(stringinstance, new object[] { "string 3" });
            methodInfo.Invoke(stringinstance, new object[] { "string 4" });
            methodInfo.Invoke(stringinstance, new object[] { "string 5" });
            var list = typeObj.GetField("_listCollection", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(stringinstance);
            foreach (var item in (List<string>)list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
