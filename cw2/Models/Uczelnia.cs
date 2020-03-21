using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cw2.Models
{
    public class Uczelnia
    {
        public Uczelnia() {
            Students = new HashSet<Student>();
            DateOfCreation = DateTime.Now.ToString("yyyy-mm-dd");
        }
        [XmlAttribute]
        public string Author { get; set; }
        [XmlAttribute(AttributeName = "CreatedAt")]
        public string DateOfCreation { get; set; }
        public HashSet<Student> Students { get; set; }
    }
}
