using System;
using System.Collections;

namespace cw2.Models
{
    public class NowStudy
    {
        public string Name { get; set; }
        public int Students { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is NowStudy element))
            {
                return false;
            }

            return element.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}