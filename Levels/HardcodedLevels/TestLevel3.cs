using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct TestLevel3
    {
        // Properties
        public static char[,] Map
        {
            get
            {
                return new char[,] { 
                    {'#', '#', '#', '#', '#', '#','#', '#', '#', '#', '#', '#'},
                    {'#', '2', 'X', 'X', ' ', '#','#', '#', ' ', ' ', '#', '#'},
                    {'#', ' ', 'B', 'B', ' ', '#','#', ' ', 'X', 'B', ' ', '#'},
                    {'#', ' ', ' ', ' ', ' ', '#','#', ' ', ' ', ' ', '1', '#'},
                    {'#', '#', '#', '#', '#', '#','#', '#', '#', '#', '#', '#'},
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
                return 20;
            }
        }

        // Methods
    }
}
