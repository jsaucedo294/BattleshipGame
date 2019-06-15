using System;
using System.Linq;

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
            
            //Choose Option to keep playing, showing score, or quiting the game.
            while (keepPlaying == true)
            {
                Console.WriteLine("Press Options:\n1:Play Game\n2:Show Score\n3:Quit Game");
                var options = Console.ReadLine();
                if (options == "1")
                {
                    Console.WriteLine("What is your Name?");
                    var name = Console.ReadLine();

                    GameSetup battle = new GameSetup(name);
                    var score = new Score();

                    //Pick option to play AUTO or MANUAL
                    bool pickingOption = true;
                    int option = 0;
                    while (pickingOption)
                    {
                        Console.WriteLine("Do you want to play AUTO or MANUAL?\n1: AUTO\n2: MANUAL");
                        int.TryParse(Console.ReadLine(), out option);
                        if (option == 1 || option == 2)
                        {
                            pickingOption = false;
                        }

                    }
                    //Battle starts
                    battle.BattleUntilEnd(option);

                    //Check if person played before to update his/her scores
                    
                    if (battle.Enemy.HasLost)
                    {
                        score.GamesWon++;
                    }
                    else
                    {
                        score.GamesLost++;
                    }
                  
                    score.ShipsSunk += battle.Enemy.Ships.Where(s => s.isSink).Count();

                    FileReaderAndWriter.SetScores(battle, score);
                     
                  
                 
                }
                else if (options == "2")
                {
                    FileReaderAndWriter.DisplayScore();
                }
                else if (options == "3")
                {
                    Environment.Exit(0);
                }

            }
            
        }
    }
}
