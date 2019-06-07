using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Battleship_Console_Game
{
    public class Coordinates
    {
        public Point Point { get; set; }
        public CoordinateType CoordinateType { get; set; }

        public Coordinates(int x, int y)
        {
            Point = new Point(x, y);
            CoordinateType = CoordinateType.Water;
        }

        public bool isOccupiedByShip
        {
            get
            {
                return CoordinateType == CoordinateType.Battleship
                    || CoordinateType == CoordinateType.Carrier
                    || CoordinateType == CoordinateType.Cruiser
                    || CoordinateType == CoordinateType.Submarine
                    || CoordinateType == CoordinateType.Destroyer;
            }
        }

        public string WhatIsOnCoordinate => GetEnumDescription(CoordinateType);

        public string GetEnumDescription(CoordinateType coordinateType)
        {
            return coordinateType
            .GetType()
            .GetMember(coordinateType.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
            ?? coordinateType.ToString();
        }

        public bool IsAvailableForRandomShot
        {
            get
            {
                return (Point.X % 2 == 0 && Point.Y % 2 == 0) 
                    || (Point.X % 2 == 1 && Point.Y % 2 == 1);
            }
        }
    }
}
