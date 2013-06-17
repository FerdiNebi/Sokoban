using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct TestLevel5
    {
        // Properties
        public static char[,] Map
        {
            get
            {
                return new char[,] { 
                    {'#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '1', ' ', '#', '#'},
                    {'#', '#', ' ', ' ', 'B', ' ', '#', '#'},
                    {'#', '#', ' ', '#', ' ', '#', '#', '#'},
                    {'#', ' ', ' ', '#', ' ', '#', 'X', '#'},
                    {'#', ' ', '#', ' ', ' ', 'B', 'X', '#'},
                    {'#', ' ', 'B', ' ', ' ', ' ', 'X', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#'},
                };
            }
        }

        public static int TimeLimit
        {
            get
            {
                return 20;
            }
        }

        public static int MoveLimit
        {
            get
            {
                return 50;
            }
        }

        // Methods
    }
}
