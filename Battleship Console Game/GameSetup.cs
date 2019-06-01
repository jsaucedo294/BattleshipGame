using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class GameSetup
    {
        public Player Player { get; set; }
        public Player Enemy { get; set; }

        public GameSetup()
        {
            Player = new Player("Jorge");
            Enemy = new Player("Pirate");
            Player.PlaceShipsOnMap();
            Enemy.PlaceShipsOnMap();
            Player.OutputMaps();
            Enemy.OutputMaps();
        }

        public void RoundShots()
        {
             
            var pointShot = Player.FireOnShips();
            var resultShot = Enemy.MissOrHitShot(pointShot);
            Player.ProcessShotResult(pointShot, resultShot);
            

            if (!Enemy.HasLost)
            {
                pointShot = Enemy.FireOnShips();
                resultShot = Player.MissOrHitShot(pointShot);
                Enemy.ProcessShotResult(pointShot, resultShot);
            }
        }

        public void BattleUntilEnd()
        {
            while (!Player.HasLost && !Enemy.HasLost)
            {
                RoundShots();
            }

            Player.OutputMaps();
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
