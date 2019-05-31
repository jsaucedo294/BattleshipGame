using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Battleship_Console_Game
{
    public enum LotType
    {
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
