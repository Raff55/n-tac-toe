using TicTacToe;

namespace NTacToe.ConsoleApp;

public class SpecificMethods
{
    public Coordinate GetSizes()
    {
        Console.WriteLine("Enter board sizes(5x5 => 100x100) like this 5 5");
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length == 2)
            {
                if (int.TryParse(input[0], out int x) && int.TryParse(input[1], out int y))
                {
                    if (x >= 5 && x <= 100 && x == y)
                    {
                        return new Coordinate(x, y);
                    }
                }
            }
            Console.WriteLine("Invalid input");
        }

    }

    public Coordinate GetCoordinates(char[,] board, int turn)
    {
        while (true)
        {
            if (turn % 2 == 0)
                Console.WriteLine("Your turn X");
            else
                Console.WriteLine("Your turn O");
            Console.WriteLine("Enter coordinates. Ex. 2 2");
            int[] coords = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            if (coords.Length != 2 || coords[0] < 1 || coords[1] < 1 || coords[0] > board.GetLength(0) || coords[1] > board.GetLength(1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
            }
            else if (board[coords[0] - 1, coords[1] - 1] != ' ')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Field is busy");
                Console.ResetColor();
            }
            else
            {
                int x = coords[0] - 1;
                int y = coords[1] - 1;
                return new Coordinate(x, y);
            }
        }
    }

    public void PrintBoard(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (j != board.GetLength(1) - 1)
                {
                    Console.Write($" {board[i, j]} |");
                }
                else
                {
                    Console.Write($" {board[i, j]}");
                    if (i != board.GetLength(0) - 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(string.Concat(Enumerable.Repeat("_", board.GetLength(0) * 4 - 1)));
                    }
                }
            }
        }
        Console.WriteLine();
    }
}
