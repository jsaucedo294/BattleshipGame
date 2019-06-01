using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    public class Coordinates
    {
        public Point Point { get; set; }
        public LotType LotType { get; set; }

        public Coordinates(int x, int y)
        {
            Point = new Point(x, y);
            LotType = LotType.Water;
        }

        public bool isOccupiedByShip
        {
            get
            {
                return LotType == LotType.Battleship
                    || LotType == LotType.Carrier
                    || LotType == LotType.Cruiser
                    || LotType == LotType.Submarine
                    || LotType == LotType.Destroyer;
            }
        }

        public string WhatIsOnCoordinate => GetEnumDescription(LotType);

        public string GetEnumDescription(LotType lotType)
        {
            return lotType
            .GetType()
            .GetMember(lotType.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
            ?? lotType.ToString();
        }

        public bool isAvailable
        {
            get
            {
                return (Point.X % 2 == 0 && Point.Y % 2 == 0) 
                    || (Point.X % 2 == 1 && Point.Y % 2 == 1);
            }
        }
    }
}
