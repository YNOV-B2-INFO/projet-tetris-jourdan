using System;
using System.Windows.Forms;

public class Grid
{
    private int[,] grid = new int[20, 10];
    private int[,] prevCoordinates;

    public int[,] GetGrid()
    {
        return grid;
    }

    public void SetPieceWithCoordinates(int[,] coordinates, int pieceNumber)
    {
        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            this.grid[y, x] = pieceNumber;
        }
        this.prevCoordinates = coordinates;
    }

    private bool IsLineFull(int lineNumber)
    {
        //check the line here 
        for (int x = 0; x < this.grid.GetLength(1); x++)
        {
            if (this.grid[lineNumber, x] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public void TestAllLines(Label label)
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            if (this.IsLineFull(y))
            {
                DeleteLine(y);
                int newScore = int.Parse(label.Text) + 90;
                label.Text = newScore.ToString();
            }
        }
    }

    public void DeleteLine(int lineNumber)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[lineNumber, j] = 0;
        }
        for (int i = lineNumber; i > 0; i--)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = grid[i - 1, j];
            }
        }
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[0, j] = 0;
        }
    }

    public void RemovePrevCoordinates(int[,] coordinates)
    {
        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            this.grid[y, x] = 0;
        }
    }

}
