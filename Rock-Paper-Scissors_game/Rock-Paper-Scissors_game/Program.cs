using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ConsoleTables;

class Program
{
    static void Main(string[] args)
    {
        // Check if at least 3 arguments are provided
        if (args.Length < 3)
        {
            Console.WriteLine("Error: You must provide at least 3 moves in command line arguments.");
            Console.WriteLine("Example: rock paper scissors");
            return;
        }

        // Check if the number of moves are odd
        if (args.Length % 2 == 0)
        {
            Console.WriteLine("Error: You must provide an odd number of moves in command line arguments.");
            Console.WriteLine("Example: rock paper scissors or rock Spock paper lizard scissors");
            return;
        }

        // Check for repeated moves
        if (args.Distinct().Count() != args.Length)
        {
            Console.WriteLine("Error: Moves must be unique and not repeated.");
            Console.WriteLine("Example: rock paper scissors or rock Spock paper lizard scissors");
            return;
        }

        // If validation is passed, start the game
        Game game = new Game(args);
        game.Start();
    }
}

class Game
{
    private string[] moves;
    private string computerMove;
    private byte[] hmacKey;
    private string hmac;

    public Game(string[] moves)
    {
        this.moves = moves;
    }

    public void Start()
    {
        GenerateComputerMove();
        PrintHMAC();
        ShowMenu();
        GetUserMove();
    }

    private void GenerateComputerMove()
    {
        RandomNumberGenerator rng = RandomNumberGenerator.Create();
        int moveIndex = RandomNumberInRange(rng, 0, moves.Length);
        computerMove = moves[moveIndex];

        // Generate 256-bit HMAC key
        hmacKey = new byte[32];
        rng.GetBytes(hmacKey);

        // Compute HMAC using SHA-256
        using (HMACSHA256 hmacsha256 = new HMACSHA256(hmacKey))
        {
            byte[] computerMoveBytes = Encoding.UTF8.GetBytes(computerMove);
            byte[] hash = hmacsha256.ComputeHash(computerMoveBytes);
            hmac = BitConverter.ToString(hash).Replace("-", "");
        }
    }

    private int RandomNumberInRange(RandomNumberGenerator rng, int minValue, int maxValue)
    {
        byte[] randomBytes = new byte[4];
        rng.GetBytes(randomBytes);
        int randomValue = BitConverter.ToInt32(randomBytes, 0);
        return Math.Abs(randomValue % (maxValue - minValue)) + minValue;
    }

    private void PrintHMAC()
    {
        Console.WriteLine($"HMAC: {hmac}");
    }

    private void ShowMenu()
    {
        Console.WriteLine("Available moves:");
        for (int i = 0; i < moves.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {moves[i]}");
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    private void GetUserMove()
    {
        while (true)
        {
            Console.Write("Enter your move: ");
            string input = Console.ReadLine();

            if (input == "?")
            {
                HelpTable helpTable = new HelpTable(moves);
                helpTable.DisplayHelpTable();
            }
            else if (input == "0")
            {
                Console.WriteLine("Exiting...");
                return;
            }
            else if (int.TryParse(input, out int userMoveIndex) && userMoveIndex > 0 && userMoveIndex <= moves.Length)
            {
                string userMove = moves[userMoveIndex - 1];
                Console.WriteLine($"Your move: {userMove}");
                Console.WriteLine($"Computer move: {computerMove}");
                DetermineWinner(userMove, computerMove);
                Console.WriteLine($"HMAC key: {BitConverter.ToString(hmacKey).Replace("-", "")}");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                ShowMenu();
            }
        }
    }

    private void DetermineWinner(string userMove, string computerMove)
    {
        int userIndex = Array.IndexOf(moves, userMove);
        int computerIndex = Array.IndexOf(moves, computerMove);

        if (userIndex == computerIndex)
        {
            Console.WriteLine("It's a draw!");
        }
        else if ((userIndex > computerIndex && userIndex <= computerIndex + moves.Length / 2) ||
                 (userIndex < computerIndex && userIndex + moves.Length > computerIndex + moves.Length / 2))
        {
            Console.WriteLine("You lose!");
        }
        else
        {
            Console.WriteLine("You win!");
        }
    }
}

class HelpTable
{
    private string[] moves;

    public HelpTable(string[] moves)
    {
        this.moves = moves;
    }

    public void DisplayHelpTable()
    {
        var table = new ConsoleTable(new[] { "v PC\\User >" }.Concat(moves).ToArray());

        for (int i = 0; i < moves.Length; i++)
        {
            var row = new string[moves.Length + 1];
            row[0] = moves[i];

            for (int j = 0; j < moves.Length; j++)
            {
                if (i == j)
                    row[j + 1] = "Draw";
                else if ((j > i && j <= i + moves.Length / 2) || (j < i && j + moves.Length <= i + moves.Length / 2))
                    row[j + 1] = "Lose";
                else
                    row[j + 1] = "Win";
            }

            table.AddRow(row);
        }

        table.Write(Format.Minimal);
    }
}
