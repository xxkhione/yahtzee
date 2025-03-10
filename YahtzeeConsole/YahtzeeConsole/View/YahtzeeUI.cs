﻿using System;
using System.Drawing;
using YahtzeeConsole.Controller;
using YahtzeeConsole.Model;
namespace YahtzeeConsole.View
{
    internal class YahtzeeUI
    {
        public static int MenuSelection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ____    ____  ___       __    __  .___________.________   _______  _______ ");
            Console.WriteLine(@" \   \  /   / /   \     |  |  |  | |           |       /  |   ____||   ____|");
            Console.WriteLine(@"  \   \/   / /  ^  \    |  |__|  | `---|  |----`---/  /   |  |__   |  |__   ");
            Console.WriteLine(@"   \_    _/ /  /_\  \   |   __   |     |  |       /  /    |   __|  |   __|  ");
            Console.WriteLine(@"     |  |  /  _____  \  |  |  |  |     |  |      /  /----.|  |____ |  |____ ");
            Console.WriteLine(@"     |__| /__/     \__\ |__|  |__|     |__|     /________||_______||_______|");
            Console.WriteLine("""
                     1. Start Single Player Game
                     2. Start Local Multiplayer game 
                     3. How to play
                     4. Scoring rules 
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
            Console.WriteLine(new string('-', 35));

            string[] topLabels = { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes" };
            string[] bottomLabels = { "Three of a Kind", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yahtzee", "Chance", "Bonus Yahtzee(s)" };
            int bottomSpace = 11;

            for(int i = 0; i < topLabels.Length; i++)
            {
                string topScore = scoreBoard.TopSection[i];
                string bottomScore = i < bottomLabels.Length ? scoreBoard.BottomSection[i] : "";
                string bottomLabel = i < bottomLabels.Length ? bottomLabels[i] : "";
                if (topLabels[i].Length == 4)
                {
                    Console.WriteLine($"{topLabels[i]}: {topScore}   | {bottomLabel}: {bottomScore}");
                } else if (topLabels[i].Length == 5)
                {
                    Console.WriteLine($"{topLabels[i]}: {topScore}  | {bottomLabel}: {bottomScore}");
                } else
                {
                    Console.WriteLine($"{topLabels[i]}: {topScore} | {bottomLabel}: {bottomScore}");
                }
            }
            for(int i = topLabels.Length; i < bottomLabels.Length; i++)
            {
                string bottomScore = scoreBoard.BottomSection[i];
                Console.WriteLine($"{new string(' ', bottomSpace)}| {bottomLabels[i]}: {bottomScore}");
            }

            Console.WriteLine(new string('-', 35));
        }
        public static void FinalScore(int score, int playerNumber)
        {
            int ActualPlayerNumber = playerNumber + 1;
            Console.WriteLine("Player: " + ActualPlayerNumber + ": " + score);
        }

        public static ScoreOptions GetScoreType(Dictionary<ScoreOptions, int> playerScoreOptions)
        {
            List<ScoreOptions> availableOptions = playerScoreOptions.Where(kvp => kvp.Value > 0)
                .Select(kvp => kvp.Key).ToList();

            while (true)
            {
                Console.WriteLine("Select a score option:");

                for (int i = 0; i < availableOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableOptions[i]}");
                }

                Console.Write("Enter the number of your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedIndex) &&
                    selectedIndex > 0 && selectedIndex <= availableOptions.Count)
                {
                    return availableOptions[selectedIndex - 1];
                }

                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        public static ScoreOptions GetScoreType(List<ScoreOptions> playerScoreOptions)
        {

            while (true)
            {
                Console.WriteLine("Select a score option:");

                for (int i = 0; i < playerScoreOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playerScoreOptions[i]}");
                }

                Console.Write("Enter the number of your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedIndex) &&
                    selectedIndex > 0 && selectedIndex <= playerScoreOptions.Count)
                {
                    return playerScoreOptions[selectedIndex - 1];
                }

                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }
}
