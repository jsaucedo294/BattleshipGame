using System;
using System.Collections.Generic;
using System.Linq;
using static Battleship_Console_Game.Enums;

namespace Battleship_Console_Game
{
    public class Player
    {
        public string Name { get; set; }
        public Map Map { get; set; }
        public Radar Radar { get; set; }
        public List<Ship> Ships { get; set; }
        public bool HasLost
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
            Console.WriteLine("Map:                          Radar:");
            for (int row = 1; row <= 8; row++)
            {
                for (int myCol = 1; myCol <= 8; myCol++)
                {
                    Console.Write(Map.Coordinates.GetAt(row, myCol).WhatIsOnCoordinate + " ");
                }
                Console.Write("                 ");
                for (int radarCol = 1; radarCol <= 8; radarCol++)
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
                    var startRow = randomPosition.Next(1, 9);
                    var startCol = randomPosition.Next(1, 9);
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
                    if (changedCoordinates.Any(c => c.isOccupiedByShip))
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

      
        public Point FireOnShips()
        {
            var hitSurroundings = Radar.GetSurroundingHits();
            Point point;

            if (hitSurroundings.Any())
            {
                point = SearchingSurroundingShots();
            }
            else
            {
                point = FireRandomShot();
            }
            Console.WriteLine(Name + " says: \"Firing shot at " + point.X.ToString() + ", " + point.Y.ToString() + "\"");
            return point;
        }
        private Point FireRandomShot()
        {
            var availableCoordinates = Radar.GetOpenCoordinatesSmart();
            Random randomHashCode = new Random(Guid.NewGuid().GetHashCode());
            var coordinateId = randomHashCode.Next(availableCoordinates.Count);
            return availableCoordinates[coordinateId];
            
        }
        private Point SearchingSurroundingShots()
        {
            Random randomHashCode = new Random(Guid.NewGuid().GetHashCode());
            var hitSurroudings = Radar.GetSurroundingHits();
            var surroudingId = randomHashCode.Next(hitSurroudings.Count);
            return hitSurroudings[surroudingId];

        }

        public ShotResult MissOrHitShot(Point point)
        {
            var coordinate = Map.Coordinates.GetAt(point.X, point.Y);
            if (!coordinate.isOccupiedByShip)
            {
                Console.WriteLine(Name + " says \"You Miss! Haha!\"");
                return Enums.ShotResult.Miss;
            }
            else { 
                var ship = Ships.First(x => x.LotType == coordinate.LotType);
                ship.Hits++;
                if (ship.isSink)
                {
                    Console.WriteLine(Name + " says \"You Sunk my " + ship.Name +"!");
                }
                Console.WriteLine(Name + " says \"Ouch! You shot my ship!");
                return Enums.ShotResult.Hit;
            }
        }

        public void ShotResult(Point point, ShotResult shotResult)
        {
            var coordinate = Radar.Coordinates.GetAt(point.X, point.Y);
            switch (shotResult)
            {
                case Enums.ShotResult.Hit:
                    coordinate.LotType = LotType.Hit;
                    break;
                default:
                    coordinate.LotType = LotType.Miss;
                    break;
            }
        }

    }
    
}
