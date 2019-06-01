using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship_Console_Game
{
    class Player
    {
        public string Name { get; set; }
        public Map Map { get; set; }
        public Radar Radar { get; set; }
        public List<Ship> Ships { get; set; }
        public bool hasLost
        {
            get
            {
                return Ships.All(s => s.isSink);
            }
        }

        public Player(string name)
        {
            Name = name;
            Map = new Map();
            Radar = new Radar();
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
                    Console.Write(Map.Coordinates.GetAt(row, myCol).WhatIsOnCoordinate + " ");
                }
                Console.Write("                 ");
                for (int radarCol = 0; radarCol < 8; radarCol++)
                {
                    Console.Write(Radar.Coordinates.GetAt(row, radarCol).WhatIsOnCoordinate + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }

        public void PlaceShipsOnMap()
        {
            //Generates a random HashCode
            Random randomPosition = new Random(Guid.NewGuid().GetHashCode());

            foreach (var ship in Ships)
            {
                bool isOpenSpace = true;
                while (isOpenSpace)
                {
                    //Random Numbers from 0 to 8 to decide on what Coordinate will the ship be placed
                    var startRow = randomPosition.Next(0, 8);
                    var startCol = randomPosition.Next(0, 8);
                    int endRow = startRow;
                    int endCol = startCol;

                   // if variable is 0 then the ship will be placed horizonal
                    var horizontalOrVertical = randomPosition.Next(1, 101) % 2;

                    List<int> coordinanceNumbers = new List<int>();

                    if (horizontalOrVertical == 0)
                    {
                        for (int i = 1; i < ship.Size; i++)
                        {
                            endRow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Size; i++)
                        {
                            endCol++;
                        }
                    }

                    //If the ship goes over the map, keep going until you find space
                    if (endRow > 8 || endCol > 8)
                    {
                        isOpenSpace = true;
                        continue;
                    }

                    //If the space is occupied, keep going until you find space
                    var changedCoordinates = Map.Coordinates.RangeOfShips(startRow, startCol, endRow, endCol);
                    if (changedCoordinates.Any(c => c.isOccupied))
                    {
                        isOpenSpace = true;
                        continue;
                    }

                    //Place ships adding the key letter for the ships
                    foreach (var coordinate in changedCoordinates)
                    {
                        coordinate.LotType = ship.LotType;
                    }
                    //Stop the while statement
                    isOpenSpace = false;
                }
            }
        }
    }
    
}
