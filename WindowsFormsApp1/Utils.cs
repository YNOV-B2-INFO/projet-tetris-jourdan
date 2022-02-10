using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using static System.Drawing.Image;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace WindowsFormsApp1
{
    internal class Utils
    {
        public Pieces CreatePieceObject()
        {
            Pieces currentPiece = null;
            Random rand = new Random();
            int pieceNumber = rand.Next(1, 5);
            switch (pieceNumber)
            {
                case 0:
                    currentPiece = new One();
                    break;
                case 1:
                    currentPiece = new L();
                    break;
                case 2:
                    currentPiece = new R();
                    break;
                case 3:
                    currentPiece = new S();
                    break;
                case 4:
                    currentPiece = new T();
                    break;
                default:
                    break;
            }
            currentPiece.pieceNumber = pieceNumber;
            return currentPiece;
        }

        public void AddPieceInGrid(Pieces currentPiece, int[,] grid)
        {
            int[,] coordinates = currentPiece.coordinates;
            int pieceNumber = currentPiece.pieceNumber;

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];

                grid[x, y] = pieceNumber;
            }
        }

        public void UpdateGrid(Pieces currentPiece, int[,] grid)
        {
            int[,] coordinates = currentPiece.coordinates;
            int[,] prevCoordinates = currentPiece.prevCoordinates;
            int pieceNumber = currentPiece.pieceNumber;

            for (int i = 0; i < prevCoordinates.GetLength(0); i++)
            {
                int x = prevCoordinates[i, 0];
                int y = prevCoordinates[i, 1];

                grid[x, y] = 0;
            }

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

        public void DisplayPieceGraphics(Pieces currentPiece, PictureBox pictureBox1)
        {
            Bitmap draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics canvas = Graphics.FromImage(draw);
            int[,] coordinates = currentPiece.coordinates;
            System.Drawing.SolidBrush myBrush = currentPiece.color;


            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                canvas.FillRectangle(myBrush, coordinates[i, 1] * 32, coordinates[i, 0] * 32, 32, 32);
                pictureBox1.Image = draw;
            }
        }



        public void DisplayGridGraphics(Pieces currentPiece, int[,] grid, PictureBox pictureBox1)
        {
            System.Drawing.SolidBrush myBrush = currentPiece.color;
            Bitmap draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics canvas = Graphics.FromImage(draw);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] != 0)
                    {
                        canvas.FillRectangle(myBrush, j * 32, i * 32, 32, 32);
                    }
                }
            }
            pictureBox1.Image = draw;


            
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
