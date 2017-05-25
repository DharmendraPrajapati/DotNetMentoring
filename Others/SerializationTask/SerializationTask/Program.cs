using SerializationTask.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

//TODO: usused usings
namespace SerializationTask
{
    //TODO: Access modifier
     internal class Program
    {
        private static void Main()
        {
            var deSerializeAndSerialize = new DeSerializeAndSerialize();
            deSerializeAndSerialize.XmlDeserialize();            
            Catalog catalog = deSerializeAndSerialize.XmlDeserialize();           
            deSerializeAndSerialize.SerealizeXml(@"sample.xml", catalog);
            deSerializeAndSerialize.SeralizeJson(catalog);
            Console.Read();
        }
    }
}