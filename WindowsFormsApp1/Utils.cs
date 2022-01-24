using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Utils
    {
        public void Create_Piece(int[,] grid, List<Pieces> allPieces)
        {
            Random rand = new Random();
            int pieceNumber = rand.Next(1, 5);
            int position = rand.Next(0, 9);
            switch (pieceNumber)
            {
                case 0:
                    allPieces.Add(new One());
                    break;
                case 1:
                    allPieces.Add(new L());
                    break;
                case 2:
                    allPieces.Add(new R());
                    break;
                case 3:
                    allPieces.Add(new S());
                    break;
                case 4:
                    allPieces.Add(new T());
                    break;
                default:
                    break;
            }
            int[,] coordinates = allPieces[allPieces.Count() - 1].CreatePiece(position);
            displayPiece(coordinates, grid, pieceNumber);
        }

        private void displayPiece(int[,] coordinates, int[,] grid, int pieceNumber)
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];

                grid[x, y] = pieceNumber;
            }
        }

        public void displayGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
