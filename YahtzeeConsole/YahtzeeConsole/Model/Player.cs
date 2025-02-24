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

        public List<ScoreOptions> PlayerScoreOptions { get; set; } = new List<ScoreOptions>();

        public Player()
        {
            ScoreBoard = new ScoreBoard();
            Score = 200;
            initializeScoreOptions();
        }

        private void initializeScoreOptions()
        {
            PlayerScoreOptions.Add(ScoreOptions.ones);
            PlayerScoreOptions.Add(ScoreOptions.twos);
            PlayerScoreOptions.Add(ScoreOptions.threes);
            PlayerScoreOptions.Add(ScoreOptions.fours);
            PlayerScoreOptions.Add(ScoreOptions.fives);
            PlayerScoreOptions.Add(ScoreOptions.sixes);
            PlayerScoreOptions.Add(ScoreOptions.three_of_a_kind);
            PlayerScoreOptions.Add(ScoreOptions.four_of_a_kind);
            PlayerScoreOptions.Add(ScoreOptions.full_house);
            PlayerScoreOptions.Add(ScoreOptions.small_straight);
            PlayerScoreOptions.Add(ScoreOptions.large_straight);
            PlayerScoreOptions.Add(ScoreOptions.yahtzee);
            PlayerScoreOptions.Add(ScoreOptions.chance);
        }
    }
}
