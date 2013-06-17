using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct TestLevel4
    {
        // Properties
        public static char[,] Map
        {
            get
            {
                return new char[,] { 
                    {'#','#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#','#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#','#', ' ', ' ', ' ', '#', '#', '#', '#'},
                    {'#','#', 'X', ' ', 'B', '#', '#', '#', '#'},
                    {'#','#', 'X', ' ', '1', ' ', ' ', '#', '#'},
                    {'#','#', '#', 'B', ' ', '#', ' ', '#', '#'},
                    {'#','#', '#', ' ', ' ', ' ', ' ', '#', '#'},
                    {'#','#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#','#', '#', '#', '#', '#', '#', '#', '#'},
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
                return 40;
            }
        }

        // Methods
    }
}
