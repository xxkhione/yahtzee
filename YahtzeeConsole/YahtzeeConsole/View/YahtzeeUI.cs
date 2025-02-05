using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeConsole.View
{
    internal class YahtzeeUI
    {
        public static int MenuSelection()
        {
            Console.WriteLine("""
                    1. Start Single Player Game
                    2. Start Local Multiplayer Game
                    3. How To Play
                    4. Quit
                    """);
            return PromptForInt("Pick an option:", 1, 4);
        }

        private static int PromptForInt(string prompt, int min, int max)
        {
            bool success = false;
            int response;
            do
            {
                Console.WriteLine(prompt);
                success = int.TryParse(Console.ReadLine(), out response);
                success = success && response >= min && response <= max;

                if(!success)
                {
                    Console.WriteLine("You entered an invalid number. Please try again.");
                }
            } while (!success);
            return 0;
        }
    }
}
