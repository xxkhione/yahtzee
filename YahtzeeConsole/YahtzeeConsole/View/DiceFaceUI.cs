using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahtzeeConsole.Model;

namespace ScratchConsole
{
    public class DiceFaceUI
    {
        public static void printDiceFace(List<int> diceRolls)
        {
            string[] top = new string[diceRolls.Count];
            string[] middle = new string[diceRolls.Count];
            string[] bottom = new string[diceRolls.Count];

            for (int i = 0; i < diceRolls.Count; i++)
            {
                var diceFace = getDiceFaceNum(diceRolls[i]);
                top[i] = diceFace[0];
                middle[i] = diceFace[1];
                bottom[i] = diceFace[2];
            }
            Console.WriteLine(string.Join("  ", Enumerable.Repeat(" ___ ", diceRolls.Count)));
            Console.WriteLine(string.Join("  ", top));
            Console.WriteLine(string.Join("  ", middle));
            Console.WriteLine(string.Join("  ", bottom));
            Console.WriteLine(string.Join("  ", Enumerable.Repeat("|___|", diceRolls.Count)));

        }

        public static string[] getDiceFaceNum(int diceNum)
        {
            switch (diceNum)
            {
                case 1:
                    return [ "|   |", "| * |", "|   |" ];
                case 2:
                    return [ "|*  |", "|   |", "|  *|" ];
                case 3:
                    return [ "|*  |", "| * |", "|  *|" ];
                case 4:
                    return [ "|* *|", "|   |", "|* *|" ];
                case 5:
                    return [ "|* *|", "| * |", "|* *|" ];
                case 6:
                    return [ "|* *|", "|* *|", "|* *|" ];
                default:
                    throw new ArgumentException("Invalid dice number");
            }
        }
    }
}
