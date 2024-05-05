using System;
using System.Collections.Generic;
using System.Text;

namespace Wheel_Of_Fortune
{
    public class Puzzle
    {
        private string solution;
        private HashSet<char> guessedLetters;  // Tracks guessed letters
        private Dictionary<string, List<string>> AllPuzzles;  // Stores categories and puzzles
        public string DisplayedPuzzle { get; private set; }

        public Puzzle()
        {
            InitializePuzzles();
            SelectRandomPuzzle();
            guessedLetters = new HashSet<char>();  // Initialize the guessed letters set
        }

        private void InitializePuzzles()
        {
            AllPuzzles = new Dictionary<string, List<string>>
            {
                { "people", new List<string> { "Ada Lovelace", "Elon Musk" } },
                { "places", new List<string> { "Paris", "New York" } },
                { "things", new List<string> { "Smartphone", "Backpack" } }
            };
        }

        private void SelectRandomPuzzle()
        {
            Random rand = new Random();
            string category = AllPuzzles.Keys.ElementAt(rand.Next(AllPuzzles.Count));
            solution = AllPuzzles[category][rand.Next(AllPuzzles[category].Count)];
            DisplayedPuzzle = new string('_', solution.Length);
        }

        public void UpdateDisplayedPuzzle(char guessedLetter)
        {
            if (!guessedLetters.Contains(char.ToUpper(guessedLetter)))
            {
                guessedLetters.Add(char.ToUpper(guessedLetter));
                var sb = new StringBuilder(DisplayedPuzzle);
                for (int i = 0; i < solution.Length; i++)
                {
                    if (char.ToUpper(solution[i]) == char.ToUpper(guessedLetter))
                        sb[i] = guessedLetter;
                }
                DisplayedPuzzle = sb.ToString();
            }
        }

        public bool Contains(char letter)
        {
            return solution.ToUpper().Contains(char.ToUpper(letter));
        }

        public bool IsGuessed(char letter)
        {
            return guessedLetters.Contains(char.ToUpper(letter));
        }

        public int CountLetter(char letter)
        {
            int count = 0;
            foreach (char c in solution.ToUpper())
            {
                if (c == char.ToUpper(letter)) count++;
            }
            return count;
        }

        public bool IsSolved()
        {
            return !DisplayedPuzzle.Contains('_');
        }
    }
}
