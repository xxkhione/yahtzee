using System;
using System.Collections.Generic;
using System.Linq;
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
        public void startGame(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player());
            }
             _currentPlayer = _players.First();
            //Console.WriteLine($"player: {_players.IndexOf(_currentPlayer) + 1} Round: {_CurrentRound}"); // TODO: Add a reference to this in DisplayScoreBoard
            YahtzeeUI.DisplayScoreBoard(_currentPlayer.ScoreBoard);
            StartRound();
        }

        public void SwitchTurns()
        {
            int currentIndex = _players.IndexOf(_currentPlayer);
            if (_CurrentRound == TotalRounds && _players.IndexOf(_currentPlayer) == _players.Count - 1)
            {
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
            Console.WriteLine($"player: {_players.IndexOf(_currentPlayer) + 1} Round: {_CurrentRound}"); // TODO: call a YahtzeeUI method for this
            StartRound();
        }

        public void StartRound()
        {
            StartPlayerTurn();
            SwitchTurns();
        }



        public void StartPlayerTurn()
        {
            List<int> dice = DiceRoller.RollDice(5); //gets initial dice roll
            for (int i = 0; i < NumberOfRerolls; i++) { //lets player reroll their dice
                DiceFaceUI.printDiceFace(dice);
                dice = ReRollingDice(dice);
            }
            //player dice rolls for their turn are complete

            // TODO: calculate score here

            Console.Clear(); // TODO: call a YahtzeeUI method for all of this
            Console.WriteLine("Here is your final dice rolls:");
            DiceFaceUI.printDiceFace(dice);
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            Console.Clear();
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

                Console.WriteLine("\nSelect which dice to reroll. When finished, write 'done'.");
                string input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "done") break;

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

    }
}
