using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SomeOtherDomain
{
    public class PlugIn : MarshalByRefObject
    {
        public void SomeMethod(List<string> values)
        {
            Console.WriteLine("SomeOtherDomainClass Current Domain FriendlyName: {0}",
                              AppDomain.CurrentDomain.FriendlyName);
            foreach(var item in values)
            {
                Console.WriteLine(item);
            }
        }

        public Assembly GetAssembly(string assemblyPath)
        {
            try
            {
                return Assembly.LoadFile(assemblyPath);
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }
    }
}