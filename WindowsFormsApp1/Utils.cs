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
            DisplayPiece(coordinates, grid, pieceNumber);
        }

        private void DisplayPiece(int[,] coordinates, int[,] grid, int pieceNumber)
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];

                grid[x, y] = pieceNumber;
            }
        }

        public void DisplayGrid(int[,] grid)
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

        public System.Drawing.SolidBrush GenerateBrush()
        {
            Random random = new Random();
            int nbr = random.Next(1, 4);


            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Transparent);
            switch (nbr)
            {
                case 1:
                    myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    break;
                case 2:
                    myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    break;
                case 3:
                    myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                    break;
                case 4:
                    myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
                    break;
            }
            return myBrush;
        }
    }
}
