using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cw2.Models
{
    public class Uczelnia
    {
        public Uczelnia()
        {
            Students = new HashSet<Student>();
            DateEst = DateTime.Now.ToString("yyyy-mm-dd");
            nowStudy = new HashSet<NowStudy>();
        }

        [XmlAttribute] public String Author { get; set; }

        [XmlAttribute(AttributeName = "Created at")]
        public string DateEst { get; set; }

        public HashSet<Student> Students { get; set; }
        public HashSet<NowStudy> nowStudy { get; set; }

        public NowStudy getNow(NowStudy element)
        {
            if (nowStudy.Contains(element))
            {
                foreach (NowStudy now in nowStudy)
                {
                    if (element.Equals(now))
                        return now;
                }
            }

            return null;
        }
    }
}