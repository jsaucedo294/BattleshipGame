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
            bool keepPlaying = true;
            int gameNum = 0;
            while (keepPlaying == true)
            {
                Console.WriteLine("Press Options:\n1:Play Game\n2:Show Score\n3:Quit Game");
                var options = Console.ReadLine();
                if (options == "1")
                {
                    GameSetup game1 = new GameSetup();
                    game1.BattleUntilEnd();
                    if (game1.Enemy.HasLost)
                    {
                        gameNum++;
                    }
                }
                else if (options == "2")
                {
                    Console.WriteLine($"Games Won: {gameNum}");
                }
                else if (options == "3")
                {
                    Environment.Exit(0);
                }

            }
            
        }
    }
}
