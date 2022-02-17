using System;
using System.Windows.Forms;

public class Grid
{
    //global vars
    private int[,] grid = new int[20, 10];
    private int[,] prevCoordinates;

    //getter to get the grid var
    public int[,] GetGrid()
    {
        return grid;
    }

    //add piece in the grid based on coordinates
    public void AddPieceWithCoordinates(int[,] coordinates, int pieceNumber)
    {
        //run through coordinates to add them in grid 
        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            this.grid[y, x] = pieceNumber;
        }
        this.prevCoordinates = coordinates;
    }

    //test the lines one by one to see if it is full
    //if the line is full, the func delete the lines and makes the lines on tp of it go down 
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

    //check if the line at index Y is full
    private bool IsLineFull(int lineNumber)
    {
        for (int x = 0; x < this.grid.GetLength(1); x++)
        {
            if (this.grid[lineNumber, x] == 0)
            {
                return false;
            }
        }
        return true;
    }

    //check if the line at index Y is empty
    public bool IsLineEmpty(int lineNumber)
    {
        for (int x = 0; x < this.grid.GetLength(1); x++)
        {
                Console.Write(this.grid[lineNumber, x]);
            if (this.grid[lineNumber, x] != 0)
            {
                return false;
            }
        }
        Console.WriteLine();
        return true;
    }

    //Delete the line at the given y index 
    //make all the lines above the y  go down 
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

    //delete the piece at the previous coordinates 
    public void RemovePrevCoordinates(int[,] coordinates)
    {
        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            this.grid[y, x] = 0;
        }
    }

    //Reset the grid 
    public void ClearGrid()
    {
        grid = new int[20, 10];
    }

}
