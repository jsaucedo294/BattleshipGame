using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsoleGame
{
    class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Size = 3;
            CoordinateType = CoordinateType.Submarine;
        }
    }
}
