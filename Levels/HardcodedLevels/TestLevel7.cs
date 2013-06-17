using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct TestLevel7
    {
        // Properties
        public static char[,] Map
        {
            get
            {
                return new char[,] { 
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                    {'#', ' ', ' ', ' ', 'B', ' ', ' ', ' ', '#'},
                    {'#', ' ', ' ', 'B', 'B', 'B', ' ', ' ', '#'},
                    {'#', ' ', 'B', 'B', '1', 'B', 'B', ' ', '#'},
                    {'#', ' ', ' ', 'B', 'B', 'B', ' ', ' ', '#'},
                    {'#', ' ', ' ', ' ', 'B', ' ', ' ', ' ', '#'},
                    {'#', '#', '#', '#', '#', '#', ' ', '#', '#'},
                    {'#', 'X', 'X', 'X', ' ', '#', ' ', '#', '#'},
                    {'#', 'X', 'X', 'X', ' ', '#', ' ', '#', '#'},
                    {'#', 'X', 'X', 'X', ' ', ' ', ' ', '2', '#'},
                    {'#', 'X', 'X', ' ', ' ', 'X', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#'},
                };
            }
        }

        public static int TimeLimit
        {
            get
            {
                return -1;
            }
        }

        public static int MoveLimit
        {
            get
            {
                return -1;
            }
        }

        // Methods
    }
}
