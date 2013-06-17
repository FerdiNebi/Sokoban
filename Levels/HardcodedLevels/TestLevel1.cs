﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct TestLevel1
    {
        // Properties
        public static char[,] Map
        {
            get
            {
                return new char[,] { 
                    {' ', '#', '#', '#', '#', ' '},
                    {'#', '#', ' ', ' ', '#', '#'},
                    {'#', ' ', 'X', 'B', ' ', '#'},
                    {'#', ' ', ' ', ' ', '1', '#'},
                    {'#', '#', '#', '#', '#', ' '},
                };
            }
        }


        public static int TimeLimit
        {
            get
            {
                return 10;
            }
        }

        public static int MoveLimit
        {
            get
            {
                return 5;
            }
        }

        // Methods
    }
}
