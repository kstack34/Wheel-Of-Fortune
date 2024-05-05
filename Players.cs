using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wheel_Of_Fortune
{
    public class Players
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int IncorrectGuesses { get; private set; }

        public Players(string name)
        {
            Name = name;
            Score = 0;
            IncorrectGuesses = 0;
        }
        public void UpdateScore(int points)
        {
            if (points < 0)
            {
                IncorrectGuesses++;
            }
            Score += points;
        }
        public void ResetScore()
        {
            Score = 0;
            IncorrectGuesses = 0;
        }
        public override string ToString()
        {
            return $"{Name} - Score: {Score}, Incorrect Guesses: {IncorrectGuesses}";
        }
    }
}
