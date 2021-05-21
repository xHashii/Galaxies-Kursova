using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxies
{
    class Program
    {
        static void Main(string[] args)
        {
            var galaxies = new Dictionary<string, Galaxy>();
            var stars = new Dictionary<string, Star>();
            var planets = new Dictionary<string, Planet>();
            var moons = new Dictionary<string, Moon>();
            while (true)
            {
                var input = Console.ReadLine();
                input = input.Replace('[', '*').Replace(']', '*');
                var unsplitSub = input.Split("*", StringSplitOptions.None);
                List<string> sub = new List<string>();
                sub = sub.Concat(unsplitSub[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToList();
                foreach (var _unsplit in unsplitSub.Skip(1).SkipLast(1))
                {
                    if(!string.IsNullOrWhiteSpace(_unsplit))
                        sub.Add(_unsplit);
                }
                sub = sub.Concat(unsplitSub.TakeLast(1).First().Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToList();


                var mainOption = sub[0].ToLower();
                var option = sub[1].ToLower();

                if (mainOption == "add")
                {
                    if (option == "galaxy")
                    {
                        var name = sub[2];
                        var type = Enum.Parse<Galaxy.Type>(sub[3]);
                        var age = sub[4];
                        galaxies.Add(name.ToLower(), new Galaxy() { Name = name, Age = age, GalaxyType = type });
                    }
                    else if(option == "star")
                    {
                        var galaxyName = sub[2];
                        var name = sub[3];
                        var mass = float.Parse(sub[4]);
                        var size = float.Parse(sub[5]);
                        var temp = int.Parse(sub[6]);
                        var lumin = float.Parse(sub[7]);
                        stars.Add(name.ToLower(), new Star()
                        {Name = name, Mass = mass, Size = size, Temp = temp, Lumin = lumin });

                        galaxies[galaxyName.ToLower()].Stars.Add(stars[name.ToLower()]);
                    }
                    else if(option == "planet")
                    {
                        var starName = sub[2];
                        var name = sub[3];
                        var planetType = sub[4];
                        var flag = string.Equals(sub[5], "yes", StringComparison.OrdinalIgnoreCase);

                        planets.Add(name.ToLower(), new Planet()
                        { Name = name, PlanetType = planetType, Habitable = flag });

                        stars[starName.ToLower()].Planets.Add(planets[name.ToLower()]);
                    }
                    else if(option == "moon")
                    {
                        var planetName = sub[2];
                        var name = sub[3];
                        moons.Add(name.ToLower(), new Moon()
                        { Name = name });
                        planets[planetName.ToLower()].Moons.Add(moons[name.ToLower()]);
                    }
                }
                else if(mainOption == "list")
                {
                    if (option == "galaxies")
                    {
                        Console.WriteLine("-- List of researched galaxies --");
                        foreach (var galaxy in galaxies)
                        {
                            Console.WriteLine(galaxy.Value.Name);
                        }
                        Console.WriteLine("-- End of galaxies list --");
                    }
                    else if(option == "stars")
                    {
                        Console.WriteLine("-- List of researched stars --");
                        foreach (var star in stars)
                        {
                            Console.WriteLine(star.Value.Name);
                        }
                        Console.WriteLine("-- End of stars list --");
                    }
                    else if (option == "planets")
                    {
                        Console.WriteLine("-- List of researched planets --");
                        foreach (var planet in planets)
                        {
                            Console.WriteLine(planet.Value.Name);
                        }
                        Console.WriteLine("-- End of planets list --");
                    }
                    else if (option == "moons")
                    {
                        Console.WriteLine("-- List of researched moons --");
                        foreach (var moon in moons)
                        {
                            Console.WriteLine(moon.Value.Name);
                        }
                        Console.WriteLine("-- End of moons list --");
                    }
                }
                else if(mainOption == "stats")
                {
                    Console.WriteLine("-- Stats --");
                    Console.WriteLine($"Galaxies: {galaxies.Count}");
                    Console.WriteLine($"Stars: {stars.Count}");
                    Console.WriteLine($"Planets: {planets.Count}");
                    Console.WriteLine($"Moons: {moons.Count}");
                    Console.WriteLine("-- End of stats --");
                }
                else if(mainOption == "print")
                {
                    var galaxy = sub[1];
                    Console.WriteLine($"-- Data for {galaxy} galaxy --");
                    Console.WriteLine(galaxies[galaxy.ToLower()].ToString());
                }
                else if(mainOption == "exit")
                {
                    break;
                }
            }
        }
    }
}
