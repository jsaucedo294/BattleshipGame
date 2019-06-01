using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Game
    {
        static void Main(string[] args)
        {
            GameSetup game1 = new GameSetup();
            game1.BattleUntilEnd();

            Console.ReadLine();
        }
    }
}
