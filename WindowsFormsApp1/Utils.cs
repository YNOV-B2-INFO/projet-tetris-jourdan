using System;
using System.Drawing;
using System.Windows.Forms;

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

        public void DisplayGridGraphics(Pieces currentPiece, int[,] grid, PictureBox pictureBox1)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            Bitmap draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics canvas = Graphics.FromImage(draw);

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y,x] != 0)
                    {
                        DisplayGrid(grid);
                        canvas.FillRectangle(myBrush, x * 32, y * 32, 32, 32);
                    }
                }
            }
            pictureBox1.Image = draw;
        }

        public void Moove(string direction, Pieces currentPiece, Grid grid, PictureBox pictureBox1, Form form1)
        {
            switch (direction)
            {
                case "left":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.GoLeft();
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    grid.TestAllLines();
                    form1.Refresh();
                    break;
                case "right":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.GoRight();
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    grid.TestAllLines();
                    form1.Refresh();
                    break;
                case "down":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.GoDown(grid.GetGrid());
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    grid.TestAllLines();
                    form1.Refresh();
                    break;
                case "rotate":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.Rotate();
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    grid.TestAllLines();
                    form1.Refresh();
                    break;
                default:
                    break;
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
