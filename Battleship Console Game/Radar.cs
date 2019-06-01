using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Radar : Map
    {
       
        public List<Point> GetOpenCoordinates()
        {
            return Coordinates.Where(x => x.LotType == LotType.Water && x.isAvailable).Select(x => x.Point).ToList();
        }

        public List<Coordinates> GetSurroundingCoordinates(Point point)
        {
            int row = point.X;
            int col = point.Y;

            List<Coordinates> coordinates = new List<Coordinates>();

            if (col > 0)
            {
                coordinates.Add(Coordinates.GetAt(row, col - 1));
            }
            if (col < 8)
            {
                coordinates.Add(Coordinates.GetAt(row, col + 1));
            }

            if (row > 0)
            {
                coordinates.Add(Coordinates.GetAt(row - 1, col));
            }
            if (row < 8)
            {
                coordinates.Add(Coordinates.GetAt(row + 1 , col));
            }
            return coordinates;
        }

        public List<Point> GetSurroundingHits()
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            var hits = Coordinates.Where(c => c.LotType == LotType.Hit);

            foreach (var hit in hits)
            {
                coordinates.AddRange(GetSurroundingCoordinates(hit.Point).ToList());
            }
            return coordinates.Distinct().Where(x => x.LotType == LotType.Water).Select(x => x.Point).ToList();
        }
    }
}
