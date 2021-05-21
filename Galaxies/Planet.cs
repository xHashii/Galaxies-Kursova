using System.Collections.Generic;
using System.Linq;

namespace Galaxies
{
    public class Planet
    {

        public string Name { get; set; }
        public string PlanetType { get; set; }
        public bool Habitable { get; set; }
        public List<Moon> Moons { get; set; } = new List<Moon>();
        public override string ToString()
        {
            var moons_string = Moons.Aggregate("", (result, moon) => result+"\t\t\t"+moon.Name+"\n");
            return $"\t\tName: {Name}\n" +
                $"\t\tType: {PlanetType}\n" +
                $"\t\tSupport Life: {(Habitable ? "Yes" : "No")}\n" +
                $"\t\tMoons:\n" +
                $"{moons_string}";
        }
    }
}