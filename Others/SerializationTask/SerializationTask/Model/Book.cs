using System;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SerializationTask.Model
{
    [Serializable]
    [XmlType("book")]
    public class Book
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("isbn")]
        public string ISBN { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [XmlElement("genre")]
        public Genere Genere { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("registration_date")]
        public DateTime RegistrationDate { get; set; }

        public override string ToString()
        {
            string formattedDate = $"{PublishDate:yyyy-dd-MM}";
            _stringBuilder.Append(
                string.Format("Tile: " + Title + "\n" + "Author: " + Author + "\n" + "Publisher: " + Publisher + "\n" +
                              "Publish Date: " + formattedDate + "\n"));
            return _stringBuilder.ToString();
        }
    }

    
}