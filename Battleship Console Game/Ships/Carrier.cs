using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Size = 5;
            LotType = LotType.Carrier;
        }
    }
}
