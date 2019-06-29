using System.ComponentModel;

namespace BattleshipConsoleGame
{
    public enum CoordinateType { 
        [Description("~")]
        Water,
        [Description("X")]
        Hit,
        [Description("M")]
        Miss,
        [Description("B")]
        Battleship,
        [Description("D")]
        Destroyer,
        [Description("A")]
        Carrier,
        [Description("C")]
        Cruiser,
        [Description("S")]
        Submarine
    }

    public enum ShotResult
    {
        Miss,
        Hit
    }
}
