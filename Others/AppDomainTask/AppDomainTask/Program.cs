using SomeOtherDomain;
using System;
using System.Collections.Generic;
using System.IO;

namespace AppDomainTask
{
    internal class Program
    {
        private static AppDomain _otherDomain;

        private static void Main()
        {
            _otherDomain = AppDomain.CreateDomain("SomeOtherDomain");
            var otherType = typeof(PlugIn);
            var objectInstance =
                    (PlugIn)_otherDomain.CreateInstanceAndUnwrap(otherType.Assembly.FullName, otherType.FullName);
            var strings = new List<string> {"s1", "s2", "1", "2"};
            Console.WriteLine("AppDomain Current Domain FriendlyName: {0}", AppDomain.CurrentDomain.FriendlyName);
            objectInstance.SomeMethod(strings);
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SomeOtherDomain.dll");
            var point = objectInstance.GetAssembly(path).FullName;
            Console.WriteLine(point);
            AppDomain.Unload(_otherDomain);
            Console.Read();
        }
    }
}