using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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





    }
}
