using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeConsole.Model
{
    public class DiceRoller
    {
        private const int min = 1;
        private const int max = 6;
        public static List<int> RollDice(int numberOfRolls)
        {
            List<int> diceRolls = new List<int>();
            for (int i = 0; i < numberOfRolls; i++)
            {
                Random random = new Random();
                diceRolls.Add(random.Next(min, max + 1));
            }
            return diceRolls;
        }

        public static List<int> RollDice(int numberOfRolls, int min, int max)
        {
            List<int> diceRolls = new List<int>();
            for (int i = 0; i < numberOfRolls; i++)
            {
                Random random = new Random();
                diceRolls.Add(random.Next(min, max + 1));
            }
            return diceRolls;
        }
    }
}
