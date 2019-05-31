using System;
using System.Collections.Generic;

namespace Battleship_Console_Game
{
    class Map
    {
       public List<Coordinates> Coordinates { get; set; }

        public Map()
        {
            Coordinates = new List<Coordinates>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Coordinates.Add(new Coordinates(i, j));
                }
            }
        }
    }
}
