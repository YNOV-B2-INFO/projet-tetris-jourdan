using System;

public class Grid
{
    private int[,] grid = new int[20, 10];
    private int[,] prevCoordinates;

    public int[,] GetGrid()
    {
        return grid;
    }

    public void displayPrevCoord()
    {
        Console.WriteLine("----------prev coordinates----------");
        for (int x = 0; x < this.prevCoordinates.GetLength(0); x++)
        {
            Console.WriteLine("x = " + this.prevCoordinates[x, 0] + " y = " + this.prevCoordinates[x, 1]);
        }
    }

    public void SetPieceWithCoordinates(int[,] coordinates, int pieceNumber)
    {
        Console.WriteLine("----------set piece with coordinates----------");
        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];

            this.grid[y, x] = pieceNumber;
        }
        this.prevCoordinates = coordinates;
        this.displayPrevCoord();
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

    public bool TestAllLines()
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            if (this.IsLineFull(y))
            {
                Console.WriteLine("LINE IS FULL");
                //del line here
            }
        }
        return true;
    }

    public void DeleteLine(int lineNumber)
    {
        //delete the line passed in parameter 
        //make all lines on top go down 

        /*for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[line, j] = 0;
        }
        for (int i = line; i < 0; i--)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = grid[i - 1, j];
            }
        }
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[0, j] = 0;
        }*/
    }
        
    public void RemovePrevCoordinates(int[,] coordinates)
    {
        Console.WriteLine("----------remove prev coordinates----------");
        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            this.grid[y, x] = 0;
        }
    }
}
