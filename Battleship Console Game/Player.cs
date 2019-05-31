using Battleship_Console_Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship_Console_Game
{
    class Player
    {
        public string Name { get; set; }
        public Map Map { get; set; }
        public List<Ship> Ships { get; set; }

        public Player(string name)
        {
            Name = name;
            Map = new Map();
            Ships = new List<Ship>
            {
                new Battleship(),
                new Carrier(),
                new Submarine(),
                new Cruiser(),
                new Destroyer()
            };

        }

        public void OutputMaps()
        {
            Console.WriteLine("My Map:                          Radar:");
            for (int row = 0; row < 8; row++)
            {
                for (int myCol = 0; myCol < 8; myCol++)
                {
                    Console.Write(Map.Coordinates.Where(x => x.Point.X == row && x.Point.Y == myCol).First().WhatIsOnCoordinate + " ");
                }
                Console.Write("                 ");
                for (int radarCol = 0; radarCol < 8; radarCol++)
                {
                    Console.Write(Map.Coordinates.Where(x => x.Point.X == row && x.Point.Y == radarCol).First().WhatIsOnCoordinate + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
    }
    
}
