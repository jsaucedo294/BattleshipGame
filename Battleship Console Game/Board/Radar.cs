using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipConsoleGame
{
    public class Radar : Map
    {
       
        public List<Point> GetOpenCoordinatesSmart()
        {
            return Coordinates.Where(x => x.CoordinateType == CoordinateType.Water && x.IsAvailableForRandomShot).Select(x => x.Point).ToList();
        }
        public List<Point> GetOpenCoordinatesLeft()
        {
            return Coordinates.Where(x => x.CoordinateType == CoordinateType.Water).Select(x => x.Point).ToList();
        }



        public List<Coordinates> GetSurroundingCoordinates(Point point)
        {
            int row = point.X;
            int col = point.Y;

            List<Coordinates> coordinates = new List<Coordinates>();

            if (col > 1)
            {
                coordinates.Add(Coordinates.GetAt(row, col - 1));
            }

            if (row > 1)
            {
                coordinates.Add(Coordinates.GetAt(row - 1, col));
            }
            if (row < 8)
            {
                coordinates.Add(Coordinates.GetAt(row + 1 , col));
            }
            if (col < 8)
            {
                coordinates.Add(Coordinates.GetAt(row, col + 1));
            }
            return coordinates;
        }

        public List<Point> GetSurroundingHits()
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            var hits = Coordinates.Where(c => c.CoordinateType == CoordinateType.Hit);

            foreach (var hit in hits)
            {
                coordinates.AddRange(GetSurroundingCoordinates(hit.Point).ToList());
            }
            return coordinates.Distinct().Where(x => x.CoordinateType == CoordinateType.Water).Select(x => x.Point).ToList();
        }
    }
}
