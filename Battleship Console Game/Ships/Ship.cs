
namespace Battleship_Console_Game
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public CoordinateType CoordinateType { get; set; }
        public bool isSink { get { return Hits >= Size; } }
    }
}
    