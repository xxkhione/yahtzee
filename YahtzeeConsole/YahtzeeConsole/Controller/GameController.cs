using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahtzeeConsole.Model;

namespace YahtzeeConsole.Controller
{
    public class GameController
    {
        private const int TotalRounds = 10;
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
            Console.WriteLine($"player: {_players.IndexOf(_currentPlayer) + 1} Round: {_CurrentRound}"); // TODO: call YahtzeeUI method for this
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
            Console.WriteLine($"player: {_players.IndexOf(_currentPlayer) + 1} Round: {_CurrentRound}"); // TODO: call YahtzeeUI method for this
            StartRound();
        }

        public void StartRound()
        {
            // TODO: continue game logic here
            SwitchTurns();
        }

        public void ReRollingDice(List<int> dices)
        {
            int reRoll = 0;
            List<int> diceIndexesToReRoll = new List<int>();

            while (true)
            {
                // Display the current dice with index numbers
                Console.WriteLine("\nCurrent Dice Rolls:");
                for (int i = 0; i < dices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {dices[i]}");
                }

                Console.WriteLine("\nSelect which dice to reroll. When finished, write 'done'.");
                string input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "done") break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= dices.Count)
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
                    Console.WriteLine("Invalid input. Enter a number between 1 and " + dices.Count);
                }
            }

            if (reRoll > 0)
            {
                List<int> newRolls = DiceRoller.RollDice(reRoll);
                for (int i = 0; i < diceIndexesToReRoll.Count; i++)
                {
                    dices[diceIndexesToReRoll[i]] = newRolls[i];
                }
            }
            Console.WriteLine("\nHere is your final dice rolls:");
            for (int i = 0; i < dices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {dices[i]}");
            }
        }

    }
}
