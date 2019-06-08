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
            
            while (keepPlaying == true)
            {
                Console.WriteLine("Press Options:\n1:Play Game\n2:Show Score\n3:Quit Game");
                var options = Console.ReadLine();
                if (options == "1")
                {
                    
                    GameSetup battle = new GameSetup();
                    var scores = battle.Scores;
                    foreach (var score in scores)
                    {
                        
                        battle.BattleUntilEnd();

                        if (battle.Enemy.HasLost)
                        {
                            score.GamesWon++;
                            score.TotalPlayed++;
                        }
                        else
                        {
                            score.TotalPlayed++;
                        }
                        score.ShipsSunk += battle.Enemy.Ships.Where(s => s.isSink).Count();
                        FileReaderAndWriter.SetScores(battle, score);
                    }
                 
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
