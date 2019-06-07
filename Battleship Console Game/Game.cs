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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("  ____        _   _   _           _     _       ");
            Console.WriteLine(" | __ )  __ _| |_| |_| | ___  ___| |__ (_)_ __  ");
            Console.WriteLine(" |  _ \\ / _` | __| __| |/ _ \\/ __| '_ \\| | '_ \\ ");
            Console.WriteLine(" | |_) | (_| | |_| |_| |  __/\\__ \\ | | | | |_) |");
            Console.WriteLine(" |____/ \\__,_|\\__|\\__|_|\\___||___/_| |_|_| .__/ ");
            Console.WriteLine("                                         |_|    ");
            Console.Write(Environment.NewLine);
            bool keepPlaying = true;
            int gameNum = 0;
            int shipsDestroyed = 0;
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
                    shipsDestroyed += game1.Enemy.Ships.Where(s => s.isSink).Count();


                }
                else if (options == "2")
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("╔═╗┌─┐┌─┐┬─┐┌─┐");
                    Console.WriteLine("╚═╗│  │ │├┬┘├┤ ");
                    Console.WriteLine("╚═╝└─┘└─┘┴└─└─┘");
                    Console.WriteLine($"Games Won: {gameNum}");
                    Console.WriteLine($"Ships Sunk: {shipsDestroyed}");
                    Console.Write(Environment.NewLine);
                }
                else if (options == "3")
                {
                    Environment.Exit(0);
                }

            }
            
        }
    }
}
