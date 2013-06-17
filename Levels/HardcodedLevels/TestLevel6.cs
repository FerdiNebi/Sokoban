using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct TestLevel6
    {
        // Properties
        public static char[,] Map
        {
            get
            {
                return new char[,] { 
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', ' ', ' ', '1', '#'},
                    {'#', '#', '#', '#', '#', 'B', 'B', ' ', '#'},
                    {'#', 'X', '#', '#', '#', ' ', 'B', ' ', '#'},
                    {'#', 'X', '#', '#', '#', ' ', '#', '#', '#'},
                    {'#', 'X', ' ', ' ', ' ', ' ', '#', '#', '#'},
                    {'#', ' ', ' ', '#', ' ', ' ', ' ', '#', '#'},
                    {'#', '#', '#', '#', ' ', ' ', ' ', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#'},
                };
            }
        }


        public static int TimeLimit
        {
            get
            {
                return 30;
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
