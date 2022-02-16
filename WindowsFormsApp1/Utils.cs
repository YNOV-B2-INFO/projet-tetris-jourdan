using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    internal class Utils
    {
        public Pieces CreatePieceObject()
        {
            Pieces currentPiece = null;
            Random rand = new Random();
            int pieceNumber = rand.Next(1, 6);
            switch (pieceNumber)
            {
                case 1:
                    currentPiece = new One();
                    break;
                case 2:
                    currentPiece = new L();
                    break;
                case 3:
                    currentPiece = new R();
                    break;
                case 4:
                    currentPiece = new S();
                    break;
                case 5:
                    currentPiece = new T();
                    Console.WriteLine("t");
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
            System.Drawing.SolidBrush myBrush = currentPiece.color;
            Bitmap draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics canvas = Graphics.FromImage(draw);
            System.Drawing.SolidBrush[] allBrushes = new System.Drawing.SolidBrush[]
            {
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 243, 2, 125)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 252, 139, 80)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 83, 36, 240)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 17, 181, 228)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 86, 227, 159))
            };
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    switch (grid[y, x])
                    {
                        case 0:
                            break;
                        case 1:

                        default:
                            break;
                    }
                    if (grid[y,x] != 0)
                    {
                        canvas.FillRectangle(allBrushes[grid[y,x] - 1], x * 32, y * 32, 32, 32);
                        canvas.DrawRectangle(pen, x * 32, y * 32, 32, 32);
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
                    form1.Refresh();
                    break;
                case "right":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.GoRight();
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    form1.Refresh();
                    break;
                case "down":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.GoDown(grid.GetGrid());
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    form1.Refresh();
                    break;
                case "rotate":
                    DisplayGridGraphics(currentPiece, grid.GetGrid(), pictureBox1);
                    grid.RemovePrevCoordinates(currentPiece.coordinates);
                    currentPiece.Rotate();
                    currentPiece.CheckBorder();
                    grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    form1.Refresh();
                    break;
                default:
                    break;
            }
        }

        public void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.choriste);
            simpleSound.PlayLooping();
        }
    }
}
