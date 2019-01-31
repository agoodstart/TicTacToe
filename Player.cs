using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        public string name;
        public char icon;

        public Player(string name, char icon)
        {
            this.name = name;
            this.icon = icon;
        }
    }
}
