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
            foreach (var dice in diceRolls)
            {
                Console.WriteLine(" ___ ");
                getDiceFaceNum(dice);
                Console.WriteLine("|___|");
                Console.WriteLine();
            }
        }

        public static void getDiceFaceNum(int diceNum)
        {
            switch (diceNum)
            {
                case 1:
                    Console.WriteLine("|   |");
                    Console.WriteLine("| * |");
                    Console.WriteLine("|   |");
                    break;
                case 2:
                    Console.WriteLine("|*  |");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|  *|");
                    break;
                case 3:
                    Console.WriteLine("|*  |");
                    Console.WriteLine("| * |");
                    Console.WriteLine("|  *|");
                    break;
                case 4:
                    Console.WriteLine("|* *|");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|* *|");
                    break;
                case 5:
                    Console.WriteLine("|* *|");
                    Console.WriteLine("| * |");
                    Console.WriteLine("|* *|");
                    break;
                case 6:
                    Console.WriteLine("|* *|");
                    Console.WriteLine("|* *|");
                    Console.WriteLine("|* *|");
                    break;

                default:
                    Console.WriteLine("Invalid dice number. Try again.");
                    return;

            }
        }
    }
}
