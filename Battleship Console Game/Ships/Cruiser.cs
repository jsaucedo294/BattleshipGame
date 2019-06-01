using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Size = 3;
            LotType = LotType.Cruiser;
        }
    }
}
