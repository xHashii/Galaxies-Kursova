using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxies
{
    public class Star
    {
        public string Name { get; set; }
        public float Mass { get; set; }
        public float Size { get; set; }
        public int Temp { get; set; }
        public float Lumin { get; set; }
        
        private char _cacheClass = ' ';
        public char Class => GetClass();

        public List<Planet> Planets { get; set; } = new List<Planet>();

        private char GetClass()
        {
            if(_cacheClass != ' ')
            {
                return _cacheClass;
            }
            var r = Size / 2;
            if (r >= 6.6 && Mass >= 16 && Lumin >= 30000 && Temp >= 30000)
            {
                _cacheClass = 'O';
            }
            else if(r < 6.6 && r >= 1.8 &&
                Mass < 16 && Mass >= 2.1 &&
                Lumin < 30000 && Lumin >= 25 &&
                Temp < 30000 && Temp >= 10000)
            {
                _cacheClass = 'B';
            }
            else if (r < 1.8 && r >= 1.4 &&
                Mass < 2.1 && Mass >= 1.4 &&
                Lumin < 25 && Lumin >= 5 &&
                Temp < 10000 && Temp >= 7500)
            {
                _cacheClass = 'A';
            }
            else if (r < 1.4 && r >= 1.15&&
                Mass < 1.4 && Mass >= 1.04 &&
                Lumin < 5 && Lumin >= 1.5 &&
                Temp < 7500 && Temp >= 6000)
            {
                _cacheClass = 'F';
            }
            else if (r < 1.15 && r >= 0.96 &&
                Mass < 1.04 && Mass >= 0.8 &&
                Lumin < 1.5 && Lumin >= 0.6 &&
                Temp < 6000 && Temp >= 5200 )
            {
                _cacheClass = 'G';
            }
            else if (r < 0.96 && r >= 0.7 &&
                Mass < 0.8 && Mass >= 0.45 &&
                Lumin < 0.6 && Lumin >= 0.08 &&
                Temp < 5200 && Temp >= 3700 )
            {
                _cacheClass = 'K';
            }
            else if (r <= 0.7 &&
              Mass < 0.45 && Mass >= 0.08 &&
              Lumin <= 0.08 &&
              Temp < 3700 && Temp >= 2400)
            {
                _cacheClass = 'M';
            }
            return _cacheClass;

        }
    
    
        public override string ToString()
        {
            var planets_string = Planets.Aggregate("", (result, planet) => result+"\n"+planet);
            return $"\tName: {Name}\n" +
                $"\tClass: {GetClass()} ({Mass}, {Size}, {Temp}, {Lumin})\n" +
                $"\tPlanets:{planets_string}";
        }

    }
}