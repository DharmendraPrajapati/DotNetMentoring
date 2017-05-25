using Newtonsoft.Json;
using SerializationTask.Model;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace SerializationTask
{
    public class DeSerializeAndSerialize
    {
        public Catalog XmlDeserialize()
        {
            #region DeSerializeBooks
            Catalog catalog;
            try
            {
                var filePath = ConfigurationManager.AppSettings["xmlFilePath"];
                var xmlSerializer = new XmlSerializer(typeof(Catalog));                
                var xmlTextReader = new XmlTextReader(filePath) {Namespaces = false};
                var data = (Catalog) xmlSerializer.Deserialize(xmlTextReader);
                Console.WriteLine(data.CatalogDate.ToString(CultureInfo.CurrentCulture));
                foreach (var book in data.Books)
                {
                    Console.WriteLine(book.Id.ToString(CultureInfo.CurrentCulture));
                    Console.WriteLine(book.Genere);
                    Console.WriteLine(book.PublishDate.ToShortDateString());
                    Console.WriteLine(book.RegistrationDate.ToShortDateString());
                }

                catalog = data;
            }
            catch (Exception exception)
            {
                Console.WriteLine(" InnerException: {0} \n Source: {1} \n Message: {2}  ", exception.InnerException,
                    exception.Source, exception.Message);
                throw;
            }
            #endregion DeSerializeBooks

            return catalog;

        }

        public void SerealizeXml(string fileName, Catalog catalog)
        {
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("xmlns", "http://library.by/catalog");
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Catalog));
                xml.Serialize(stream, catalog, xmlSerializerNamespaces);
            }
        }

        public void SeralizeJson(Catalog catalog)
        {
            var jsonPath = ConfigurationManager.AppSettings["jsonFilePath"];

            var json = JsonConvert.SerializeObject(catalog, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "yyyy-dd-MM"
            });

            var jsonSerializer = new JsonSerializer();

            using (var sw = new StreamWriter(jsonPath))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    jsonWriter.DateFormatString = "yyyy-dd-MM";
                    jsonSerializer.Serialize(jsonWriter, catalog);
                }
            }

            Console.WriteLine(json);
        }
    }
}