namespace NTacToe.Logic;

/// <summary>
/// Represents a coordinate with X and Y values.
/// </summary>
public struct Coordinate
{
    /// <summary>
    /// Gets or sets the X value of the coordinate.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Gets or sets the Y value of the coordinate.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Initializes a new instance of the Coordinate struct with the specified X and Y values.
    /// </summary>
    /// <param name="x">The X value of the coordinate.</param>
    /// <param name="y">The Y value of the coordinate.</param>
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}