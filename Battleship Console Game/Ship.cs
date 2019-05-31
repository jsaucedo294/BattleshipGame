using System;

namespace Battleship_Console_Game
{
    class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set }
        public LotType LotType { get; set; }
        public bool isSink { get { return Hits >= Size; } }
    }
}
