using TicTacToe.Players;

namespace TicTacToe;

public class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Title = "TicTacToe 1.0";
            Console.Clear();
            Console.WriteLine("=== TicTacToe 1.0 ===\n");
            Console.WriteLine("1. Player vs Player");
            Console.WriteLine("2. Player vs Random");
            Console.WriteLine("3. Player vs AI");
            Console.WriteLine("4. Simulate Random vs Random");
            Console.WriteLine("5. Simulate Random vs AI");
            Console.WriteLine("6. Simulate AI vs AI");
            Console.WriteLine("0. Exit\n");

            while (true)
            {
                Console.Write("Select type of game [0-6]: ");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());
                        break;
                    case 2:
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                        break;
                    case 3:
                        PlayGame(new ConsolePlayer(), new AIPlayer());
                        break;
                    case 4:
                        Simulate(new RandomPlayer(), new RandomPlayer(), 10);
                        break;
                    case 5:
                        Simulate(new RandomPlayer(), new AIPlayer(), 10);
                        break;
                    case 6:
                        Simulate(new AIPlayer(), new AIPlayer(), 10);
                        break;
                }

                if (choise >= 0 && choise <= 6) break;
            }

            Console.Write("Please enter for a new game!");
            Console.ReadLine();
        }
    }

    private static void PlayGame(IPlayer player1, IPlayer player2)
    {
        Game game = new Game(player1, player2);
        var result = game.Play();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Game over!");
        Console.WriteLine(result.Winner == Symbol.None ? "Winner: Draw" : $"Winner: {result.Winner}");
        Console.WriteLine(result.Board.ToString());

        Console.ResetColor();
    }

    private static void Simulate(IPlayer player1, IPlayer player2, int count)
    {
        int x = 0, o = 0, draw = 0;
        int firstWinnerWinner = 0, secondPlayerWinner = 0;
        var firstPlayer = player1;
        var secondPlayer = player2;

        for (int i = 0; i < count; i++)
        {
            var game = new Game(firstPlayer, secondPlayer);
            var result = game.Play();
            if (result.Winner == Symbol.X && firstPlayer == player1) firstWinnerWinner++;
            if (result.Winner == Symbol.O && firstPlayer == player1) secondPlayerWinner++;
            if (result.Winner == Symbol.X && firstPlayer == player2) secondPlayerWinner++;
            if (result.Winner == Symbol.O && firstPlayer == player2) firstWinnerWinner++;
            if (result.Winner == Symbol.X) x++;
            if (result.Winner == Symbol.O) o++;
            if (result.Winner == Symbol.None) draw++;

            (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
        }

        Console.WriteLine($"Games played: {count}");
        Console.WriteLine($"Games won by X: {x}");
        Console.WriteLine($"Games won by O: {o}");
        Console.WriteLine($"Draw games: {draw}");
        Console.WriteLine($"{player1.GetType().Name} won games: {firstWinnerWinner}");
        Console.WriteLine($"{player2.GetType().Name} won games: {secondPlayerWinner}");
    }
}