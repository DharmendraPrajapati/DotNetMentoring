using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializationTask.Model
{
    [Serializable]
    [XmlRoot(ElementName = "catalog")]
    [XmlType("catalog")]
    public class Catalog
    {
        public Catalog()
        {
            Books = new List<Book>();
            CatalogDate = DateTime.Now;
        }

        [XmlAttribute("date", DataType = "date")]
        public DateTime CatalogDate { get; set; }

        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}