using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Size = 4;
            LotType = Enums.LotType.Destroyer;
        }
    }
}
