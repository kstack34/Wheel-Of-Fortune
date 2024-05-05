using Wheel_Of_Fortune;

public class Gameplay
{
    private List<Players> players;
    private Wheel wheel;
    private Puzzle puzzle;
    private int currentPlayerIndex;
    private bool puzzleSolved = false;

    public Gameplay()
    {
        players = new List<Players>();
        wheel = new Wheel();
        puzzle = new Puzzle();
    }

    public void AddPlayer(string name)
    {
        players.Add(new Players(name));
    }

    public void StartGame()
    {
        while (!puzzleSolved)
        {
            Console.WriteLine("Starting a new round...");
            PlayRound();
        }
        EndGame();
    }

    private void PlayRound()
    {
        foreach (Players player in players)
        {
            currentPlayerIndex = players.IndexOf(player);
            while (PlayTurn(player) && !puzzleSolved) { }
            if (puzzleSolved) break;
        }
    }

    private bool PlayTurn(Players player)
    {
        Console.WriteLine($"{player.Name}'s turn. Press the space bar to spin the wheel.");
        Console.ReadKey(true); // Simulate spinning

        string result = wheel.Spin();
        Console.WriteLine($"Wheel landed on: {result}");
        bool continueTurn = HandleSpinResult(result, player);

        if (continueTurn)
        {
            continueTurn = GuessLetter(player);
            if (puzzle.IsSolved())
            {
                puzzleSolved = true;
                Console.WriteLine($"{player.Name} has solved the puzzle!");
            }
        }
        return continueTurn;
    }

    private bool GuessLetter(Players player)
    {
        Console.WriteLine("Current Puzzle: " + puzzle.DisplayedPuzzle);
        Console.WriteLine("Guess a letter:");
        char guess = char.ToUpper(Console.ReadKey(true).KeyChar);

        if (puzzle.IsGuessed(guess))
        {
            Console.WriteLine("This letter has already been guessed. You lose your turn.");
            return false;  // End turn if the letter was already guessed
        }

        if (puzzle.Contains(guess))
        {
            int count = puzzle.CountLetter(guess);
            if (count > 0)
            {
                puzzle.UpdateDisplayedPuzzle(guess);
                int earnedPoints = count * 100;  // Assume each letter is worth 100 points
                player.UpdateScore(earnedPoints);
                Console.WriteLine($"{player.Name} earns {earnedPoints} points! Current Puzzle: {puzzle.DisplayedPuzzle}");
                return true;  // Continue the turn if the guess is correct
            }
        }
        Console.WriteLine("No such letter in the puzzle.");
        return false;  // End the turn if the guess is incorrect
    }

    private bool HandleSpinResult(string result, Players player)
    {
        switch (result)
        {
            case "Bankrupt":
                player.ResetScore();
                Console.WriteLine($"{player.Name} has gone bankrupt!");
                return false;
            case "Lose a Turn":
                Console.WriteLine($"{player.Name} loses a turn.");
                return false;
            default:
                return true;
        }
    }

    private void EndGame()
    {
        Console.WriteLine("Game Over! Here are the final scores:");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.Score} points");
        }
        // Optionally declare a winner based on puzzle completion
        var winner = players.OrderByDescending(p => p.Score).First();
        Console.WriteLine($"Congratulations {winner.Name}, you solved the puzzle!");
    }
}
