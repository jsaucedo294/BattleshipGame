using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    public static class Extensions
    {
        public static Coordinates GetAt(this List<Coordinates> coordinates, int row, int col)
        {
            return coordinates.Where(c => c.Point.X == row && c.Point.Y == col).First();
        }

        public static List<Coordinates> RangeOfShips(this List<Coordinates> coordinates, int startRow, int startCol, int endRow, int endCol)
        {
            return coordinates.Where(c => c.Point.X >= startRow && c.Point.Y >= startCol && c.Point.X <= endRow && c.Point.Y <= endCol).ToList();
        }
    }
}
