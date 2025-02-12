using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeConsole.Model
{
    public class ScoreBoard
    {
        //A LOT of this is placeholders, I will edit these once we do our Review
        public string[] TopSection { get; set; }
        public string[] BottomSection { get; set; }

        public ScoreBoard()
        {
            TopSection = new string[6]; //Aces through Sixes
            BottomSection = new string[8]; //Everything else

            for(int i = 0; i < TopSection.Length; i++)
            {
                TopSection[i] = "--"; //Again, placeholders
            }
            for (int i = 0; i < BottomSection.Length; i++)
            {
                BottomSection[i] = "--"; //Again, placeholders
            }
        }
    }
}
