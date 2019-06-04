using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Map:                               Radar:");
            Console.Write(Environment.NewLine);
            for (int row = 1; row <= 8; row++)
            {
                Console.Write(row + " ");
                for (int myCol = 1; myCol <= 8; myCol++)
                {
                    Console.Write(Map.Coordinates.GetAt(row, myCol).WhatIsOnCoordinate + " ");
                }
                Console.Write("                 ");
                Console.Write(row + " ");
                for (int radarCol = 1; radarCol <= 8; radarCol++)
                {
                    Console.Write(Radar.Coordinates.GetAt(row, radarCol).WhatIsOnCoordinate + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("  1 2 3 4 5 6 7 8                    1 2 3 4 5 6 7 8");
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

        public Point ManaulFireOnShips()
        {
            string xInput;
            string yInput;
            int xPoint;
            int yPoint;
            do {
                Console.Write("Pick a number between 1 and 8 for the Row: ");
                xInput = Console.ReadLine();
                int.TryParse(xInput, out xPoint);
                Console.Write("Pick a number between 1 and 8 for the Column: ");
                yInput = Console.ReadLine();
                int.TryParse(yInput, out yPoint);
            } while (xPoint < 0 || xPoint > 8 || yPoint < 0 || yPoint > 8 || string.IsNullOrEmpty(xInput) || string.IsNullOrEmpty(yInput) || !(int.TryParse(xInput, out xPoint)) || !(int.TryParse(yInput, out yPoint)));


            Point point = new Point(xPoint, yPoint);
            return point;

        }

        public Point AutoFireOnShips()
        {
            var hitSurroundings = Radar.GetSurroundingHits();
            Point point;

            if (hitSurroundings.Any())
            {
                point = SearchingSurroundingShots();
            }
            else
            {
                point = AutoFireRandomShot();
            }
            Console.WriteLine(Name + " says: \"Firing shot at " + point.X.ToString() + ", " + point.Y.ToString() + "\"");
            return point;
        }
        private Point AutoFireRandomShot()
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
                return ShotResult.Miss;
            }
            
            var ship = Ships.First(x => x.LotType == coordinate.LotType);
            ship.Hits++;
            Console.WriteLine(Name + " says \"Ouch! You shot my ship!");
            if (ship.isSink)
            {
                Console.WriteLine(Name + " says \"You Sunk my " + ship.Name +"!");
            }
            
            return ShotResult.Hit;
          
        }

        public void ProcessShotResult(Player enemy, Point point, ShotResult shotResult)
        {
            var coordinateRadar = Radar.Coordinates.GetAt(point.X, point.Y);
            var coordinateMap = enemy.Map.Coordinates.GetAt(point.X, point.Y);

            switch (shotResult)
            {
                case ShotResult.Hit:
                    coordinateRadar.LotType = LotType.Hit;
                    coordinateMap.LotType = LotType.Hit;
                    break;
                default:
                    coordinateRadar.LotType = LotType.Miss;
                    coordinateMap.LotType = LotType.Miss;
                    break;
            }
            
    
        }

    }
    
}
