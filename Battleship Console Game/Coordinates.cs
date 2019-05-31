﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Console_Game
{
    class Coordinates
    {
        public Point Point { get; set; }
        public LotType LotType { get; set; }

        public Coordinates(int x, int y)
        {
            Point = new Point(x, y);
            LotType = LotType.Water;
        }

        public bool isOccupied
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

        public string WhatIsOnCoordinate => LotType.GetAttributeOfType<DescriptionAttribute>().Description;
 

    }
}