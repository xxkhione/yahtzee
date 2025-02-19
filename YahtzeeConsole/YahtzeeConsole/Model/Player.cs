using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeConsole.Model
{
    public class Player
    {
        public ScoreBoard ScoreBoard { get; set; }
        public int Score { get; set; }

        public Player()
        {
            ScoreBoard = new ScoreBoard();
            Score = 0;
        }
    }
}
