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
    }
}
