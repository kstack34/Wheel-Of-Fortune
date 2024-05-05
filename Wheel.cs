using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Threading;

namespace Wheel_Of_Fortune
{
    public class Wheel
    {
        private string[] segments = new string[]
        {
            "Bankrupt", "500", "400", "250", "Lose a Turn", "800", "350", "450", "700", "300", "600", "5000", "200",
            "3500", "Bankrupt", "500", "200", "Lose a Turn", "400", "200", "900", "250", "300", "900", "Free Play"
        };
        private Random random = new Random();

        public string Spin()
        {
            int minSpins = 14;
            int maxSpins = 24;
            int spinStrength = random.Next(minSpins, maxSpins + 1);
            int delay = 50;  // Initial delay for spinning speed

            Console.Clear();

            for (int i = 0; i < spinStrength; i++)
            {
                Console.Clear();
                int index = i % segments.Length;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Spinning: -->   {segments[index]}");
                Thread.Sleep(delay);

                // Gradually increase delay to simulate wheel slowing down
                if (i < spinStrength / 3)
                {
                    delay = 50;  // Faster spinning in the initial third
                }
                else if (i < 2 * spinStrength / 3)
                {
                    delay = 100;  // Slow down in the middle third
                }
                else
                {
                    delay = 200;  // Slowest spin towards the end
                }
            }

            int finalIndex = (spinStrength - 1) % segments.Length;
            Console.Clear();
            Console.WriteLine($"Wheel stops at: {segments[finalIndex]}");
            return segments[finalIndex];
        }
    }
}
