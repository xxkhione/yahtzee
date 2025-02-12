using System;
using YahtzeeConsole.Controller;
using YahtzeeConsole.Model;

namespace YahtzeeConsole.View
{
    internal class YahtzeeUI
    {
        public static int MenuSelection()
        {
            Console.Clear();
            Console.WriteLine("""
                    1. Start Single Player Game
                    2. Start Local Multiplayer Game
                    3. How To Play
                    4. Scoring Rules
                    5. Quit
                    """);

            int selection = PromptForInt("Pick an option:", 1, 5);
            return selection;
        }

        private static int PromptForInt(string prompt, int min, int max)
        {
            bool success;
            int response;
            do
            {
                Console.WriteLine(prompt);
                success = int.TryParse(Console.ReadLine(), out response) && response >= min && response <= max;
                
                if (!success)
                {
                    Console.WriteLine("You entered an invalid number. Please try again.");
                }
            } while (!success);
            return response;
        }

        public static void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("\n=== How to Play Yahtzee ===");
            Console.WriteLine("""
                1. Each player rolls five dice up to three times per turn.
                2. After each roll, you may keep some dice and re-roll the rest.
                3. After rolling, you must choose a scoring category.
                4. The game lasts 13 rounds, and each category can only be used once.
                5. The player with the highest total score at the end wins.
                """);
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
            MenuSelection();
        }

        public static void ScoringRules()
        {
            Console.Clear();
            Console.WriteLine("\n=== Scoring Rules ===");
            Console.WriteLine("""
                Upper Section:
                - Ones, Twos, Threes, Fours, Fives, Sixes: Sum of the chosen number.
                - Bonus: Score 63+ points in this section for a 35-point bonus.

                Lower Section:
                - Three of a Kind: Sum of all dice if three match.
                - Four of a Kind: Sum of all dice if four match.
                - Full House: Three of one number + two of another (25 points).
                - Small Straight: Four consecutive numbers (30 points).
                - Large Straight: Five consecutive numbers (40 points).
                - Yahtzee: Five of a kind (50 points).
                - Chance: Sum of all dice.

                Highest total score wins!
                """);
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
            MenuSelection();
        }

        public static int NumberOfPlayersSelection()
        {
            Console.Clear();
            Console.WriteLine("""
                    1. 2 player
                    2. 3 player
                    3. 4 player
                    4. 5 player
                    5. 6 player
                    6. Back to Main Menu
                    """);

            int selection = PromptForInt("Pick an option:", 1, 6);
            Console.Clear();
            return selection;
        }

        public static void DisplayScoreBoard(ScoreBoard scoreBoard)
        {
            Console.Clear(); //Simply clears the console to move the scoreboard to the top
            Console.WriteLine("Yahtzee ScoreBoard");
            Console.WriteLine(new string('-', 60));

            string[] topLabels = { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes" };
            string[] bottomLabels = { "Three of a Kind", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yahtzee", "Chance", "Bonus Yahtzee(s)" };

            for(int i = 0; i < topLabels.Length; i++)
            {
                string topScore = scoreBoard.TopSection[i];
                string bottomScore = i < bottomLabels.Length ? scoreBoard.BottomSection[i] : "";
                string bottomLabel = i < bottomLabels.Length ? bottomLabels[i] : "";
                Console.WriteLine($"{topLabels[i]}: {topScore} | {bottomLabel}: {bottomScore}");
            }
            for(int i = topLabels.Length; i < bottomLabels.Length; i++)
            {
                string bottomScore = scoreBoard.BottomSection[i];
                Console.WriteLine($"{bottomLabels[i]}: {bottomScore}");
            }

            Console.WriteLine(new string('-', 60));
        }
    }
}
