using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeConsole.Model
{
    public class ScoreBoard
    {
        public string[] TopSection { get; set; }
        public string[] BottomSection { get; set; }

        public ScoreBoard()
        {
            TopSection = new string[6]; //Aces through Sixes
            BottomSection = new string[8]; //Everything else

            for(int i = 0; i < TopSection.Length; i++)
            {
                TopSection[i] = "00";
            }
            for (int i = 0; i < BottomSection.Length; i++)
            {
                BottomSection[i] = "00";
            }
        }

        #region TopSectionScores
        public void setAces(string aces)
        {
            TopSection[0] = aces;
        }
        public void setTwos(string twos)
        {
            TopSection[1] = twos;
        }
        public void setThrees(string threes)
        {
            TopSection[2] = threes;
        }
        public void setFours(string fours)
        {
            TopSection[3] = fours;
        }
        public void setFives(string fives)
        {
            TopSection[4] = fives;
        }
        public void setSixes(string sixes)
        {
            TopSection[5] = sixes;
        }
        #endregion

        #region BottomSectionScores
        public void setThreeOfAKind(string threeOfAKind)
        {
            BottomSection[0] = threeOfAKind;
        }
        public void setFourOfAKind(string fourOfAKind)
        {
            BottomSection[1] = fourOfAKind;
        }
        public void setFullHouse(string fullHouse)
        {
            BottomSection[2] = fullHouse;
        }
        public void setSmall(string small)
        {
            BottomSection[3] = small;
        }
        public void setLarge(string large)
        {
            BottomSection[4] = large;
        }
        public void setYahtzee(string yahtzee)
        {
            BottomSection[5] = yahtzee;
        }
        public void setChance(string chance)
        {
            BottomSection[6] = chance;
        }
        public void setBonus(string bonus)
        {
            BottomSection[7] = bonus;
        }
        #endregion

        private int calculateTopScore()
        {
            int score = 0;
            for(int i = 0; i < TopSection.Length; i++)
            {
                score += int.Parse(TopSection[i]);
            }
            return score;
        }
        private int calculateBottomScore()
        {
            int score = 0;
            for (int i = 0; i < BottomSection.Length; i++)
            {
                score += int.Parse(BottomSection[i]);
            }
            return score;
        }

        public int calculateFinalScore()
        {
            return calculateTopScore() + calculateBottomScore();
        }
    }
}
