namespace NTacToe.Logic;

public class Medium
{
    /// <summary>
    /// Takes a game board represented as a 2D char array and returns an updated board after making a move.
    /// </summary>
    /// <param name="board">The game board represented as a 2D char array.</param>
    /// <returns>The updated game board after making a move.</returns>
    public char[,] Step(char[,] board)
    {
        List<Coordinate> danger = CheckAttack(board, 'X');
        List<Coordinate> useful = CheckAttack(board, 'O');
        List<Coordinate> availableSteps = CheckAvailableSteps(board, 'X');
        List<Coordinate> allSteps = CheckAllSteps(board);
        if (useful.Count > 0)
        {
            board = Board.Insert(board, useful[0], 'O');
        }
        else if (danger.Count > 0)
        {
            board = Board.Insert(board, danger[0], 'O');
        }
        else if (availableSteps.Count > 0)
        {
            board = Board.Insert(board, availableSteps[0], 'O');
        }
        
        else if (allSteps.Count > 0)
        {
            board = Board.Insert(board, allSteps[0], 'O');
        }
        return board;
    }

    /// <summary>
    /// Analyzes the board for vertical, horizontal, top-left-bottom-right, and top-right-bottom-left diagonal patterns, and returns a list of dangerous positions.
    /// </summary>
    /// <param name="board">The game board represented as a two-dimensional char array.</param>
    /// <param name="symbol">The symbol to search for in the patterns.</param>
    /// <returns>A list of Coordinate objects representing the positions of potentially dangerous spaces on the board.</returns>
    private static List<Coordinate> CheckAttack(char[,] board, char symbol)
    {
        var dangerField = new List<Coordinate>();

        #region Vertical
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                //With 4 element
                // |  | X | X | X | X | 
                if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 2, j));
                }
                // | X |  | X | X | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j));
                }
                // | X | X |  | X | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X | X |  | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j));
                }
                // | X | X | X | X |  | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 2, j));
                }
                //With 3 element
                // |  | X | X | X |  | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 2, j));
                }
                // | X | X | X |  |  | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 1, j));
                }
                // |  |  | X | X | X | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j));
                }
                // | X | X |  | X |  | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  | X | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j));
                }
                // | X |  | X | X |  | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j));
                }
                // |  | X |  | X | X | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  | X | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X |  |  | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j));
                }
            }
        }
        #endregion

        #region Horizontal
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                //With 4 elements
                // |  | X | X | X | X | 
                if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j - 2));
                }
                // | X |  | X | X | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j - 1));
                }
                // | X | X |  | X | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X | X |  | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j + 1));
                }
                // | X | X | X | X |  | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j + 2));
                }
                //With 3 elements
                // |  | X | X | X |  | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j + 2));
                }
                // | X | X | X |  |  | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j + 1));
                }
                // |  |  | X | X | X | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j - 1));
                }
                // | X | X |  | X |  | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  | X | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j + 1));
                }
                // | X |  | X | X |  | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j - 1));
                }
                // |  | X |  | X | X | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  | X | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X |  |  | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j - 1));
                }
            }
        }
        #endregion

        #region Angle
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                #region Left-Top__Right-Bottom
                //With 4 elements
                // |  | X | X | X | X | 
                if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 2, j - 2));
                }
                // | X |  | X | X | X | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j - 1));
                }
                // | X | X |  | X | X | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X | X |  | X | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j + 1));
                }
                // | X | X | X | X |  | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 2, j + 2));
                }
                //With 3 elements
                // |  | X | X | X |  | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 2, j + 2));
                }
                // | X | X | X |  |  | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 1, j + 1));
                }
                // |  |  | X | X | X | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j - 1));
                }
                // | X | X |  | X |  | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  | X | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j + 1));
                }
                // | X |  | X | X |  | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j - 1));
                }
                // |  | X |  | X | X | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  | X | X | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X |  |  | X | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  | X | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j - 1));
                }
                #endregion

                #region Right-Top__Left-Bottom
                //With 4 elements
                // |  | X | X | X | X | 
                if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 2, j + 2));
                }
                // | X |  | X | X | X | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j + 1));
                }
                // | X | X |  | X | X | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X | X |  | X | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j - 1));
                }
                // | X | X | X | X |  | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 2, j - 2));
                }
                //With 3 elements
                // |  | X | X | X |  | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 2, j - 2));
                }
                // | X | X | X |  |  | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 1, j - 1));
                }
                // |  |  | X | X | X | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j + 1));
                }
                // | X | X |  | X |  | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  | X | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j - 1));
                }
                // | X |  | X | X |  | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j + 1));
                }
                // |  | X |  | X | X | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  | X | X | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X | X |  |  | X | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  | X | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i - 1, j + 1));
                }
                #endregion
            }
        }
        #endregion

        return dangerField;
    }

    /// <summary>
    /// Identifies "danger fields" on a game board for a given symbol. A danger field represents a position on the board where placing the specified symbol would potentially give an advantage to the opponent.
    /// </summary>
    /// <param name="board">A two-dimensional array representing the game board.</param>
    /// <param name="symbol">The symbol used to represent a player's move on the board.</param>
    /// <returns>A list of coordinates representing the positions on the board that are considered danger fields.</returns>
    private List<Coordinate> CheckAvailableSteps(char[,] board, char symbol)
    {
        var dangerField = new List<Coordinate>();

        #region Vertical

        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                //With 2 elements
                // | X | X |  |  |  | 
                if (board[i - 2, j] == symbol && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == ' ' && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  |  | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 1, j));
                }
                // |  |  | X | X |  | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j));
                }
                // |  |  |  | X | X | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == ' ' && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  |  | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j));
                }
                // |  | X |  | X |  | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  |  | X |  | X | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == ' ' && board[i, j] == symbol && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j));
                }
                // | X |  |  | X |  | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == ' ' && board[i + 1, j] == symbol && board[i + 2, j] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X |  |  | X | 
                else if (board[i - 2, j] == ' ' && board[i - 1, j] == symbol && board[i, j] == ' ' && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  |  | X | 
                else if (board[i - 2, j] == symbol && board[i - 1, j] == ' ' && board[i, j] == ' ' && board[i + 1, j] == ' ' && board[i + 2, j] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
            }
        }
        #endregion

        #region Horizontal
        
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                //With 2 elements
                // | X | X |  |  |  | 
                if (board[i, j - 2] == symbol && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == ' ' && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  |  | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j + 1));
                }
                // |  |  | X | X |  | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j - 1));
                }
                // |  |  |  | X | X | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == ' ' && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  |  | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j - 1));
                }
                // |  | X |  | X |  | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  |  | X |  | X | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == ' ' && board[i, j] == symbol && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j + 1));
                }
                // | X |  |  | X |  | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == ' ' && board[i, j + 1] == symbol && board[i, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X |  |  | X | 
                else if (board[i, j - 2] == ' ' && board[i, j - 1] == symbol && board[i, j] == ' ' && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  |  | X | 
                else if (board[i, j - 2] == symbol && board[i, j - 1] == ' ' && board[i, j] == ' ' && board[i, j + 1] == ' ' && board[i, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
            }
        }
        #endregion

        #region Angle
        for (int i = 2; i < board.GetLength(0) - 2; i++)
        {
            for (int j = 2; j < board.GetLength(1) - 2; j++)
            {
                #region Left-Top__Right-Bottom
                //With 2 elements
                // | X | X |  |  |  | 
                if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  |  | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 1, j + 1));
                }
                // |  |  | X | X |  | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j - 1));
                }
                // |  |  |  | X | X | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == ' ' && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }

                // | X |  | X |  |  | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j - 1));
                }
                // |  | X |  | X |  | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  |  | X |  | X | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == ' ' && board[i, j] == symbol && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j + 1));
                }
                // | X |  |  | X |  | 
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == ' ' && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X |  |  | X | 
                else if (board[i - 2, j - 2] == ' ' && board[i - 1, j - 1] == symbol && board[i, j] == ' ' && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  |  | X |
                else if (board[i - 2, j - 2] == symbol && board[i - 1, j - 1] == ' ' && board[i, j] == ' ' && board[i + 1, j + 1] == ' ' && board[i + 2, j + 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                #endregion

                #region Right-Top__Left-Bottom
                //With 2 elements
                // | X | X |  |  |  | 
                if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X | X |  |  | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i + 1, j - 1));
                }
                // |  |  | X | X |  | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j + 1));
                }
                // |  |  |  | X | X | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == ' ' && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  | X |  |  | 
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i - 1, j + 1));
                }
                // |  | X |  | X |  | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  |  | X |  | X | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == ' ' && board[i, j] == symbol && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i + 1, j - 1));
                }
                // | X |  |  | X |  |
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == ' ' && board[i + 1, j - 1] == symbol && board[i + 2, j - 2] == ' ')
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // |  | X |  |  | X | 
                else if (board[i - 2, j + 2] == ' ' && board[i - 1, j + 1] == symbol && board[i, j] == ' ' && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                // | X |  |  |  | X |
                else if (board[i - 2, j + 2] == symbol && board[i - 1, j + 1] == ' ' && board[i, j] == ' ' && board[i + 1, j - 1] == ' ' && board[i + 2, j - 2] == symbol)
                {
                    dangerField.Add(new Coordinate(i, j));
                }
                #endregion
            }
        }
        #endregion

        for (int i = 1; i < board.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < board.GetLength(1) - 1; j++)
            {
                if (board[i, j] == ' ')
                {
                    if (board[i - 1, j - 1] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i - 1, j] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i, j - 1] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i - 1, j + 1] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i + 1, j - 1] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i + 1, j] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i, j + 1] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                    else if (board[i + 1, j + 1] == 'X')
                    {
                        dangerField.Add(new Coordinate(i, j));
                    }
                }
            }
        }
        return dangerField;
    }

    /// <summary>
    /// Generates a list of all available steps on a game board.
    /// </summary>
    /// <param name="board">A two-dimensional array representing the game board.</param>
    /// <returns>A list of coordinates representing the positions on the board where a player can make a move.</returns>
    private List<Coordinate> CheckAllSteps(char[,] board)
    {
        var steps = new List<Coordinate>();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == ' ')
                {
                    steps.Add(new Coordinate(i, j));
                }
            }
        }
        return steps;
    }
}
