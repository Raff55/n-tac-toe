namespace NTacToe.Logic;

public class Board
{
    /// <summary>
    /// Creates a square game board with the specified size.
    /// </summary>
    /// <param name="x">The size of the board (number of rows and columns).</param>
    /// <returns>A char array representing the game board.</returns>
    public static char[,] CreateBoard(int x)
    {
        char[,] board = new char[x, x];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                board[i, j] = ' ';
            }
        }
        return board;
    }

    /// <summary>
    /// Inserts a marker into the specified coordinates of the game board.
    /// </summary>
    /// <param name="board">The game board represented as a char array.</param>
    /// <param name="coordinates">The coordinates where the marker will be inserted.</param>
    /// <param name="marker">The marker to be inserted.</param>
    /// <returns>The updated game board with the marker inserted.</returns>
    public static char[,] Insert(char[,] board, Coordinate coordinates, char marker)
    {
        board[coordinates.X, coordinates.Y] = marker;
        return board;
    }

    /// <summary>
    /// Checks if there is a winning condition on the game board.
    /// </summary>
    /// <param name="board">The game board represented as a char array.</param>
    /// <returns>True if there is a winning condition, False otherwise.</returns>
    public static bool CheckWin(char[,] board)
    {
        //Vertical
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != ' ')
                {
                    char symbol = board[i, j];
                    if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                    {
                        return true;
                    }
                }
            }
        }

        //Horizontal
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                if (board[i, j] != ' ')
                {
                    char symbol = board[i, j];
                    if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                    {
                        return true;
                    }
                }
            }
        }

        //Angle
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                if (board[i, j] != ' ')
                {
                    char symbol = board[i, j];
                    if (
                         board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol ||
                         board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Checks if there is a winning condition on the game board and retrieves the coordinates of the winning line and the winning marker.
    /// </summary>
    /// <param name="board">The game board represented as a char array.</param>
    /// <param name="winnerLineCoords">The list to store the coordinates of the winning line.</param>
    /// <param name="winnerMark">The variable to store the winning marker.</param>
    /// <returns>True if there is a winning condition, False otherwise.</returns>
    public static bool CheckWin(char[,] board, ref List<Coordinate> winnerLineCoords, ref char winnerMark)
    {
        winnerLineCoords.Clear();
        //Vertical
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != ' ')
                {
                    char symbol = board[i, j];
                    if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                    {
                        winnerLineCoords.Add(new Coordinate(i - 2, j));
                        winnerLineCoords.Add(new Coordinate(i - 1, j));
                        winnerLineCoords.Add(new Coordinate(i, j));
                        winnerLineCoords.Add(new Coordinate(i + 1, j));
                        winnerLineCoords.Add(new Coordinate(i + 2, j));
                        winnerMark = symbol;
                        return true;
                    }
                }
            }
        }

        //Horizontal
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                if (board[i, j] != ' ')
                {
                    char symbol = board[i, j];
                    if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                    {
                        winnerLineCoords.Add(new Coordinate(i, j - 2));
                        winnerLineCoords.Add(new Coordinate(i, j - 1));
                        winnerLineCoords.Add(new Coordinate(i, j));
                        winnerLineCoords.Add(new Coordinate(i, j + 1));
                        winnerLineCoords.Add(new Coordinate(i, j + 2));
                        winnerMark = symbol;
                        return true;
                    }
                }
            }
        }

        //Angle
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                if (board[i, j] != ' ')
                {
                    char symbol = board[i, j];
                    if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                    {
                        winnerLineCoords.Add(new Coordinate(i - 2, j - 2));
                        winnerLineCoords.Add(new Coordinate(i - 1, j - 1));
                        winnerLineCoords.Add(new Coordinate(i, j));
                        winnerLineCoords.Add(new Coordinate(i + 1, j + 1));
                        winnerLineCoords.Add(new Coordinate(i + 2, j + 2));
                        winnerMark = symbol;
                        return true;
                    }
                    else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                    {
                        winnerLineCoords.Add(new Coordinate(i - 2, j + 2));
                        winnerLineCoords.Add(new Coordinate(i - 1, j + 1));
                        winnerLineCoords.Add(new Coordinate(i, j));
                        winnerLineCoords.Add(new Coordinate(i + 1, j - 1));
                        winnerLineCoords.Add(new Coordinate(i + 2, j - 2));
                        winnerMark = symbol;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
