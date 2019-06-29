using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsoleGame
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Size = 4;
            CoordinateType = CoordinateType.Destroyer;
        }
    }
}
