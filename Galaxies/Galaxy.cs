using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galaxies
{
    class Galaxy
    {
        public enum Type
        {
            elliptical,
            lenticular,
            spiral,
            irregular
        }
        public string Name { get; set; }
        public Type GalaxyType { get; set; }
        public string Age { get; set; }
        public List<Star> Stars { get; set; } = new List<Star>();

        public override string ToString()
        {
            var stars_string = Stars.Aggregate("", (result, star )=> result+"\n"+star.ToString());
            return $"Type: {GalaxyType}\n" +
                $"Age: {Age}\n" +
                $"Stars:{stars_string}";
        }
    }
}
