using System.Xml.Serialization;

namespace SerializationTask.Model
{
//TODO: Please assign values to enums
    public enum Genere
    {
        [XmlEnum(Name = "Computer")]
        Computer,
        [XmlEnum(Name = "Fantasy")]
        Fantasy,
        [XmlEnum(Name = "Romance")]
        Romance,
        [XmlEnum(Name = "Science Fiction")]
        ScienceFiction,
        [XmlEnum(Name = "Horror")]
        Horror
    }
}