using System;
using System.Collections.Generic;

namespace Battleship_Console_Game
{
    public class GameSetup
    {
        public Player Player { get; set; }
        public Player Enemy { get; set; }
        public List<Score> Scores { get; set; }

        public GameSetup(string name)
        {
            Player = new Player(name);
            Enemy = new Player("Pirate");
            Scores = FileReaderAndWriter.GetScores();
            Player.PlaceShipsOnMap();
            Enemy.PlaceShipsOnMap();
            Player.OutputMaps();
        }

        //Round of shots
        public void RoundShots(int option)
        {
            Point pointShot = null;
            if (option == 1)
            {
                //Player plays autoplay
                pointShot = Player.AutoFireOnShips();
            }
            else if (option == 2)
            {
                //Player plays manual
                pointShot = Player.ManualFireOnShips();
            }
            var resultShot = Enemy.MissOrHitShot(pointShot);
            Player.ProcessShotResult(Enemy, pointShot, resultShot);
            

            if (!Enemy.HasLost)
            {
                pointShot = Enemy.AutoFireOnShips();
                resultShot = Player.MissOrHitShot(pointShot);
                Enemy.ProcessShotResult(Player, pointShot, resultShot);
            }
            // Print map and radar after RoundShots
            Player.OutputMaps();
        }
        //Play until Player or Enemy looses
        public void BattleUntilEnd(int option)
        {
            if (option == 1)
            {
                while (!Player.HasLost && !Enemy.HasLost)
                {
                    RoundShots(option);
                }
            }
            else if (option == 2)
            {
                while (!Player.HasLost && !Enemy.HasLost)
                {
                    RoundShots(option);
                }
            }
            //Print Player and Enemy Board and Radar
            Console.WriteLine(Player.Name + "'s Board");
            Player.OutputMaps();

            Console.WriteLine(Enemy.Name + "'s Board");
            Enemy.OutputMaps();

            if (Player.HasLost)
            {
                Console.WriteLine(Enemy.Name + " won the battle! Whoooo");
            }
            if (Enemy.HasLost)
            {
                Console.WriteLine(Player.Name + " won the battle! Yaaaay");
            }
            
        }
            
    }
}
