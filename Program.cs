using System;

namespace Wheel_Of_Fortune
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Wheel of Fortune!");
            Console.WriteLine("Enter the number of players (1-3):");

            int playerCount = int.Parse(Console.ReadLine()); // Basic input handling, you might want to add validation
            Gameplay game = new Gameplay();

            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"Enter player {i + 1} name:");
                string name = Console.ReadLine();
                game.AddPlayer(name);
            }

            // Optionally, you can ask for a specific puzzle here or randomize it within the game setup
            Console.WriteLine("Starting the game...");
            game.StartGame();

            Console.WriteLine("Thank you for playing Wheel of Fortune!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
