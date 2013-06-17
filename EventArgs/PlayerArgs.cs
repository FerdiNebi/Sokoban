using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    class PlayerArgs : EventArgs
    {
        public int Player { get; set; }

        public PlayerArgs(int player)
            : base()
        {
            this.Player = player;
        }
    }
}
