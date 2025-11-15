using NTacToe.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NTacToe.WPF;

public partial class MainWindow : Window
{
    private int turn = 0;
    private char[,] board;
    private bool isWin;
    public List<Button> buttons = [];
    private char winner = ' ';
    private List<Coordinate> winnerLine = [];
    private List<Coordinate> history = [];

    public MainWindow()
    {
        InitializeComponent();
        modeVersion.Items.Add("With bot");
        modeVersion.Items.Add("2 Player");
    }

    /// <summary>
    /// Event handler for the "Start Game" button click event.
    /// Initializes the game board and sets up the UI elements.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">The event arguments.</param>
    private void Start(object sender, RoutedEventArgs e)
    {
        if (int.Parse(sizeX.Text) > 100 || int.Parse(sizeX.Text) < 5)
        {
            hintBlock.Foreground = Brushes.Red;
        }
        else
        {
            hintBlock.Foreground = Brushes.White;
            winnerLabel.Content = string.Empty;
            hintBlock.Text = "Your turn X";
            history.Clear();
            isWin = false;
            turn = 0;
            for (int i = 0; i < buttons.Count; i++)
            {
                boardGrid.Children.Remove(buttons[i]);
            }
            buttons.Clear();
            int x = int.Parse(sizeX.Text);
            board = Board.CreateBoard(x);
            boardGrid.ColumnDefinitions.Clear();
            boardGrid.RowDefinitions.Clear();
            for (int j = 0; j < x; j++)
            {
                RowDefinition row = new RowDefinition();
                boardGrid.RowDefinitions.Add(row);
            }
            for (int j = 0; j < x; j++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(boardGrid.Height / x);
                boardGrid.ColumnDefinitions.Add(column);
            }
            double buttonSize = boardGrid.ActualHeight / x;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Button button = new Button() { Content = board[i, j] };
                    button.Name = $"button{i}{j}";
                    buttons.Add(button);
                    button.SetValue(Grid.ColumnProperty, j);
                    button.SetValue(Grid.RowProperty, i);
                    button.FontSize = buttonSize * 0.5;
                    button.Foreground = Brushes.DarkCyan;
                    button.Margin = new System.Windows.Thickness(3, 3, 3, 3);
                    BrushConverter brushConverter = new BrushConverter();
                    button.Background = (Brush)brushConverter.ConvertFrom("#eed2ee");
                    Style buttonStyle = new Style(typeof(Button));
                    buttonStyle.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));
                    buttonStyle.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));
                    button.Style = buttonStyle;
                    if (modeVersion.SelectedItem.ToString() == "With bot")
                        button.Click += withBot_Click;
                    else
                        button.Click += twoPlayers_Click;
                    boardGrid.Children.Add(button);
                }
            }
        }
    }

    /// <summary>
    /// Event handler for the button click event in the "Two Players" mode.
    /// Handles the logic when a button is clicked in the game grid.
    /// </summary>
    /// <param name="sender">The object that triggered the event (a Button).</param>
    /// <param name="e">The event arguments.</param>
    private void twoPlayers_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = (Button)sender;
        isWin = Board.CheckWin(board);
        if ((clickedButton.Content).ToString() != " ")
        {
            hintBlock.Text = "Field is busy";
        }
        else if (isWin != true)
        {
            int row = int.Parse(clickedButton.GetValue(Grid.RowProperty).ToString());
            int col = int.Parse(clickedButton.GetValue(Grid.ColumnProperty).ToString());
            if (turn % 2 == 0)
            {
                hintBlock.Text = "Your turn O";
                clickedButton.Content = "X";
                board[row, col] = 'X';
            }
            else
            {
                hintBlock.Text = "Your turn X";
                clickedButton.Content = "O";
                board[row, col] = 'O';
            }
            turn++;
            history.Add(new Coordinate(row, col));
            isWin = Board.CheckWin(board, ref winnerLine, ref winner);
            if (turn == board.GetLength(0) * board.GetLength(1) && isWin == false)
            {
                winnerLabel.Content = "XO";
                hintBlock.Text = "Click Start Game";
            }
            else if (isWin == true)
            {
                WinStyle(winnerLine);
                if (winner == 'O')
                {
                    winnerLabel.Content = "O";
                    int owin = int.Parse((oWins.Content).ToString());
                    owin += 1;
                    oWins.Content = owin;
                }
                else
                {
                    winnerLabel.Content = "X";
                    int xwin = int.Parse((xWins.Content).ToString());
                    xwin += 1;
                    xWins.Content = xwin;
                }
                hintBlock.Text = "Click Start Game";
            }
        }
        else
        {
            hintBlock.Text = "Click Start Game";
        }
    }

    /// <summary>
    /// Event handler for the button click event in the "With Bot" mode.
    /// Handles the logic when a button is clicked in the game grid.
    /// </summary>
    /// <param name="sender">The object that triggered the event (a Button).</param>
    /// <param name="e">The event arguments.</param>
    private void withBot_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = (Button)sender;
        isWin = Board.CheckWin(board);
        if ((clickedButton.Content).ToString() != " ")
        {
            hintBlock.Text = "Field is busy";
        }
        else if (isWin != true)
        {
            int row = int.Parse(clickedButton.GetValue(Grid.RowProperty).ToString());
            int col = int.Parse(clickedButton.GetValue(Grid.ColumnProperty).ToString());

            clickedButton.Content = "X";
            board[row, col] = 'X';
            hintBlock.Text = "Your turn X";
            history.Add(new Coordinate(row, col));
            if (isWin == true)
            {
                WinStyle(winnerLine);
                if (winner == 'O')
                {
                    winnerLabel.Content = "O";
                    int owin = int.Parse((oWins.Content).ToString());
                    owin += 1;
                    oWins.Content = owin;
                }
                else
                {
                    winnerLabel.Content = "X";
                    int xwin = int.Parse(xWins.Content.ToString());
                    xwin += 1;
                    xWins.Content = xwin;

                }
                hintBlock.Text = "Click Start Game";
            }
            Medium medium = new Medium();
            board = medium.Step(board);
            Insert(board);
            turn++;

            isWin = Board.CheckWin(board, ref winnerLine, ref winner);
            if (turn == (board.GetLength(0) * board.GetLength(1)) / 2 + 1 && isWin == false)
            {
                winnerLabel.Content = "XO";
                hintBlock.Text = "Tied";
            }
            else if (isWin == true)
            {
                WinStyle(winnerLine);
                if (winner == 'O')
                {
                    winnerLabel.Content = "O";
                    int owin = int.Parse((oWins.Content).ToString());
                    owin += 1;
                    oWins.Content = owin;
                }
                else
                {
                    winnerLabel.Content = "X";
                    int xwin = int.Parse((xWins.Content).ToString());
                    xwin += 1;
                    xWins.Content = xwin;
                }
            }
        }
        else
        {
            hintBlock.Text = "Click Start Game";
        }
    }

    /// <summary>
    /// Event handler for the "sizeX" TextChanged event.
    /// Updates the content of the "sizeY" element based on the text entered in "sizeX".
    /// </summary>
    /// <param name="sender">The object that triggered the event (a TextBox).</param>
    /// <param name="e">The event arguments.</param>
    private void sizeX_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sizeY != null)
        {
            sizeY.Content = sizeX.Text;
        }
    }

    /// <summary>
    /// Event handler for the "undoButton" Click event.
    /// Handles the logic to undo the last move in the game.
    /// </summary>
    /// <param name="sender">The object that triggered the event (a Button).</param>
    /// <param name="e">The event arguments.</param>
    private void undoButton_Click(object sender, RoutedEventArgs e)
    {
        if (history.Count > 0)
        {
            if (modeVersion.SelectedItem.ToString() == "With bot")
            {
                Coordinate coord1 = history.Last();
                history.Remove(coord1);
                board[coord1.X, coord1.Y] = ' ';
                Coordinate coord2 = history.Last();
                history.Remove(coord2);
                board[coord2.X, coord2.Y] = ' ';
                Insert(board);
                turn -= 2;
            }
            else
            {
                Coordinate coord = history.Last();
                history.Remove(coord);
                board[coord.X, coord.Y] = ' ';
                Insert(board);
                turn--;
            }
        }
    }

    /// <summary>
    /// Updates the content of the buttons in the game grid based on the provided characters array.
    /// </summary>
    /// <param name="chars">The characters array representing the game grid.</param>
    private void Insert(char[,] chars)
    {
        int index = 0;
        for (int i = 0; i < chars.GetLength(0); i++)
        {
            for (int j = 0; j < chars.GetLength(1); j++)
            {
                buttons[index].Content = chars[i, j].ToString();
                index++;
                if ((chars[i, j] == 'O' || chars[i, j] == 'X') && !history.Contains(new Coordinate(i, j)))
                {
                    history.Add(new Coordinate(i, j));
                }
            }
        }
    }

    /// <summary>
    /// Updates the visual style for the buttons corresponding to the winning coordinates.
    /// </summary>
    /// <param name="coords">The list of coordinates representing the winning line.</param>
    private void WinStyle(List<Coordinate> coords)
    {
        history.Clear();
        for (int i = 0; i < coords.Count; i++)
        {
            for (int j = 0; j < buttons.Count; j++)
            {
                int row = int.Parse(buttons[j].GetValue(Grid.RowProperty).ToString());
                int col = int.Parse(buttons[j].GetValue(Grid.ColumnProperty).ToString());
                if (coords[i].X == row && coords[i].Y == col)
                {
                    ColorAnimation animation = new ColorAnimation
                    {
                        From = Colors.LightBlue,
                        To = Colors.GreenYellow,
                        Duration = TimeSpan.FromSeconds(1),
                        AutoReverse = true,
                        RepeatBehavior = new RepeatBehavior(2)
                    };

                    SolidColorBrush brush = new SolidColorBrush();
                    buttons[j].Background = brush;
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
            }
        }
    }
}
