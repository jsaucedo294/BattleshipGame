using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
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
