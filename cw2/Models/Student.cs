using System.Xml;
using System.Xml.Serialization;

namespace cw2.Models
{
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        [XmlElement(ElementName = "birthdate")]
        public string date { get; set; }

        [XmlAttribute(AttributeName = "indexNumber")]
        public string s { get; set; }

        public string Mail { get; set; }

        public string MothersName { get; set; }
        public string FathersName { get; set; }


        public Studies Studies { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Student element))
            {
                return false;
            }

            return element.Imie == this.Imie;
        }

        public override int GetHashCode()
        {
            return Imie.GetHashCode();
        }
    }
}