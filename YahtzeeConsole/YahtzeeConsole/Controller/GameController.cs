using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ScratchConsole;
using YahtzeeConsole.Model;
using YahtzeeConsole.View;

namespace YahtzeeConsole.Controller
{
    public class GameController
    {
        private const int TotalRounds = 13;
        private const int NumberOfRerolls = 3;
        private int _CurrentRound = 1;
        private List<Player> _players = new List<Player>();
        private Player _currentPlayer;
        public int totalPlayers = 0;
        public List<int> dice = new List<int>();

        public void startGame(int numberOfPlayers)
        {
            totalPlayers = numberOfPlayers; 
            for (int i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player());
            }
             _currentPlayer = _players.First();
            StartRound();
        }

        public void SwitchTurns()
        {
            int currentIndex = _players.IndexOf(_currentPlayer);
            if (_CurrentRound == TotalRounds && _players.IndexOf(_currentPlayer) == _players.Count - 1)
            {
                for( int i = 0; i < totalPlayers; i++) {
                    _currentPlayer = (Player)_players[i];
                    int finalScore = _currentPlayer.ScoreBoard.calculateFinalScore();
                    _currentPlayer.Score = finalScore;
                    YahtzeeUI.FinalScore(_currentPlayer.Score, i);
                }
                // TODO: add final score display here
                Console.WriteLine("\nPress Enter to return to the menu."); 
                Console.ReadLine();
                return; //ends the game
            }
            int nextIndex = (currentIndex + 1) % _players.Count;
            _currentPlayer = _players[nextIndex];

            if (nextIndex == 0)
            {
                _CurrentRound++;
            }
            
            StartRound();
        }

        public void StartRound()
        {

            StartPlayerTurn();
            SwitchTurns();
        }



        public void StartPlayerTurn()
        {
            YahtzeeUI.DisplayScoreBoard(_currentPlayer.ScoreBoard);
            Console.WriteLine($"player: {_players.IndexOf(_currentPlayer) + 1} Round: {_CurrentRound}"); // TODO: call a YahtzeeUI method for this
            dice = DiceRoller.RollDice(5); //gets initial dice roll
            for (int i = 0; i < NumberOfRerolls; i++) { //lets player reroll their dice
                Console.ForegroundColor = ConsoleColor.Green;
                DiceFaceUI.printDiceFace(dice);
                Console.ForegroundColor= ConsoleColor.Yellow;
                dice = ReRollingDice(dice);
            }
            //player dice rolls for their turn are complete
            Console.Clear();
            Console.WriteLine("Here is your final dice rolls:");
            Console.ForegroundColor = ConsoleColor.Green;
            DiceFaceUI.printDiceFace(dice);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Dictionary<ScoreOptions, int> possibleScores = GetPossibleScores();
            Dictionary<ScoreOptions, int> availableScores = new Dictionary<ScoreOptions, int>();
            foreach(var kvp in possibleScores)
            {
                if (_currentPlayer.PlayerScoreOptions.Contains(kvp.Key))
                {
                    availableScores.Add(kvp.Key, kvp.Value);
                }
            }

            ScoreOptions scoreOption = YahtzeeUI.GetScoreType(availableScores);
            UpdateScoreBoard(possibleScores, scoreOption);
            _currentPlayer.PlayerScoreOptions.Remove(scoreOption);

            YahtzeeUI.DisplayScoreBoard(_currentPlayer.ScoreBoard);

            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public void UpdateScoreBoard(Dictionary<ScoreOptions, int> possibleScores, ScoreOptions selectedOption)
        {
            int score = possibleScores[selectedOption];

            switch(selectedOption)
            {
                case ScoreOptions.ones:
                    _currentPlayer.ScoreBoard.setAces(score.ToString());
                    break;
                case ScoreOptions.twos:
                    _currentPlayer.ScoreBoard.setTwos(score.ToString());
                    break;
                case ScoreOptions.threes:
                    _currentPlayer.ScoreBoard.setThrees(score.ToString());
                    break;
                case ScoreOptions.fours:
                    _currentPlayer.ScoreBoard.setFours(score.ToString());
                    break;
                case ScoreOptions.fives:
                    _currentPlayer.ScoreBoard.setFives(score.ToString());
                    break;
                case ScoreOptions.sixes:
                    _currentPlayer.ScoreBoard.setSixes(score.ToString());
                    break;
                case ScoreOptions.three_of_a_kind:
                    _currentPlayer.ScoreBoard.setThreeOfAKind(score.ToString());
                    break;
                case ScoreOptions.four_of_a_kind:
                    _currentPlayer.ScoreBoard.setFourOfAKind(score.ToString());
                    break;
                case ScoreOptions.small_straight:
                    _currentPlayer.ScoreBoard.setSmall(score.ToString());
                    break;
                case ScoreOptions.large_straight:
                    _currentPlayer.ScoreBoard.setLarge(score.ToString());
                    break;
                case ScoreOptions.yahtzee:
                    _currentPlayer.ScoreBoard.setYahtzee(score.ToString());
                    break;
                case ScoreOptions.chance:
                    _currentPlayer.ScoreBoard.setChance(score.ToString());
                    break;

            }
        }



        public List<int> ReRollingDice(List<int> dice)
        {
            int reRoll = 0;
            List<int> diceIndexesToReRoll = new List<int>();

            while (true)
            {
                // Display the current dice with index numbers
                Console.WriteLine("\nCurrent Dice Rolls:");
                for (int i = 0; i < dice.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {dice[i]}");
                }

                Console.WriteLine("\nSelect which dice to reroll. When finished, press enter.");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input)) break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= dice.Count)
                {
                    if (!diceIndexesToReRoll.Contains(index - 1))
                    {
                        diceIndexesToReRoll.Add(index - 1);
                        reRoll++;
                    }
                    else
                    {
                        Console.WriteLine("You already selected this dice to reroll.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and " + dice.Count);
                }
            }

            if (reRoll > 0)
            {
                List<int> newRolls = DiceRoller.RollDice(reRoll);
                for (int i = 0; i < diceIndexesToReRoll.Count; i++)
                {
                    dice[diceIndexesToReRoll[i]] = newRolls[i];
                }
            }
            return dice;
        }

        public Dictionary<ScoreOptions, int> GetPossibleScores()
        {
            Dictionary<ScoreOptions, int> possibleScores = new Dictionary<ScoreOptions, int>();
            dice.Sort();

            //The basic ones: Ones-Sixes
            for (int i = 1; i <= 6; i++)
            {
                ScoreOptions scoreOption = (ScoreOptions)(i - 1);
                possibleScores[scoreOption] = dice.Count(dice => dice == i) * i;
            }

            //Three of a Kind
            if(HasCount(3))
            {
                possibleScores[ScoreOptions.three_of_a_kind] = dice.Sum();
            }
            //Four of a Kind
            if(HasCount(4))
            {
                possibleScores[ScoreOptions.four_of_a_kind] = dice.Sum();
            }
            //Full House
            if (IsFullHouse())
            {
                possibleScores[ScoreOptions.full_house] = 25;
            }

            //Small Straight
            if(IsStraight(4))
            {
                possibleScores[ScoreOptions.small_straight] = 30;
            }
            //Large Straight
            if(IsStraight(5))
            {
                possibleScores[ScoreOptions.large_straight] = 40;
            }
            
            //Yahtzee
            if(HasCount(5))
            {
                possibleScores[ScoreOptions.yahtzee] = 50;
            }

            //Chance
            possibleScores[ScoreOptions.chance] = dice.Sum();

            return possibleScores;
        }

        //Helper methods for the Possible Score Options
        private bool HasCount(int count)
        {
            return dice.GroupBy(dice => dice).Any(g => g.Count() >= count);
        }
        private bool IsFullHouse()
        {
            var groups = dice.GroupBy(dice => dice).ToList();
            //Checks to see if there are 2 groups
            //Then checks if those groups have 3 values and 2 values to make up a full house
            return groups.Count == 2 && groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
        }
        private bool IsStraight(int length)
        {
            var distinctDice = dice.Distinct().ToList();
            distinctDice.Sort();

            if (distinctDice.Count < length) return false;

            for(int i = 0; i <= distinctDice.Count - length; i++)
            {
                bool isStraight = true;
                for(int j = 1; j <length; j++)
                {
                    if (distinctDice[i + j] != distinctDice[i + j - 1] + 1)
                    {
                        isStraight = false;
                        break;
                    }
                }
                if (isStraight) return true;
            }
            return false;
        }
    }
}
