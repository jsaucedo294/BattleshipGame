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
            Player player1 = new Player("Jorge");

            player1.PlaceShipsOnMap();
            player1.OutputMaps();

            Console.ReadLine();
        }
    }
}
