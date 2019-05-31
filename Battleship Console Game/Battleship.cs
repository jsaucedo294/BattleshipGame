using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Size = 4;
            LotType = LotType.Battleship;
        }
    }
}
