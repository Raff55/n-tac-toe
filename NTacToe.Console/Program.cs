using NTacToe.Logic;

namespace NTacToe.ConsoleApp;

public class Program
{
    public static void Main()
    {
        bool isAgain = true;
        while (isAgain)
        {
            int turn = 0;
            SpecificMethods s = new SpecificMethods();
            Coordinate sizes = s.GetSizes();
            char[,] board = Board.CreateBoard(sizes);
            s.PrintBoard(board);
            while (true)//HaveWin
            {
                Coordinate coord = s.GetCoordinates(board, turn);
                board = Board.Insert(board, coord, ref turn);
                Console.Clear();
                s.PrintBoard(board);
                if (Board.CheckWin(board))
                {
                    if ((turn - 1) % 2 == 0)
                        Console.WriteLine("X Wins!");
                    else
                        Console.WriteLine("O Wins!");
                    break;
                }
            }
            Console.WriteLine("Do you want play again?(Yes/No)");
            isAgain = Console.ReadLine() == "Yes" ? true : false;
            Console.Clear();
        }
    }
}
