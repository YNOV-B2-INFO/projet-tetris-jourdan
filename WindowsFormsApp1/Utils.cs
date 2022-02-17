using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    internal class Utils
    {
        //color to fill the piece 
        System.Drawing.SolidBrush[] allBrushes = new System.Drawing.SolidBrush[]
            {
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 243, 2, 125)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 252, 139, 80)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 83, 36, 240)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 17, 181, 228)),
                new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 86, 227, 159))
            };
        //color to draw the border of the piece 
        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);

        //return a random piece object with the pieceNumber set 
        public Pieces CreatePieceObject()
        {
            //set the range of piece generation here 
            Pieces currentPiece = null;
            Random rand = new Random();
            int pieceNumber = rand.Next(2, 5);

            //create the object here 
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
                    break;
                default:
                    break;
            }

            //set the pieceNumber
            currentPiece.pieceNumber = pieceNumber;
            return currentPiece;
        }

        //display the grid based on the numbers in the cases 
        public void DisplayGridGraphics(int[,] grid, PictureBox pictureBox1)
        {
            //bitmap and canva to draw the piece
            Bitmap draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics canvas = Graphics.FromImage(draw);

            //test all cases of the grid 
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y,x] != 0)
                    {
                        canvas.FillRectangle(allBrushes[grid[y,x] - 1], x * 32, y * 32, 32, 32);
                        canvas.DrawRectangle(pen, x * 32, y * 32, 32, 32);
                    }
                }
            }
            pictureBox1.Image = draw;
        }

        //display the piece given in parameters in the picturebox given in parameters 
        public void DisplayOnePiece(Pieces nextPiece, PictureBox pictureBox)
        {
            Bitmap draw = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics canvas = Graphics.FromImage(draw);

            for (int y = 0; y < nextPiece.coordinates.GetLength(0); y++)
            {
                canvas.FillRectangle(allBrushes[nextPiece.pieceNumber - 1], nextPiece.coordinates[y, 0] * 25 - 80, nextPiece.coordinates[y, 1] * 25 + 60, 25, 25);
                canvas.DrawRectangle(pen, nextPiece.coordinates[y, 0] * 25 - 80, nextPiece.coordinates[y, 1] * 25 + 60, 25, 25);
            }
            pictureBox.Image = draw;
        }

        //moove the piece based on the direction given parameters 
        public void Moove(string direction, Pieces currentPiece, Grid grid, PictureBox pictureBox1, Form form1)
        {
            DisplayGridGraphics(grid.GetGrid(), pictureBox1);
            grid.RemovePrevCoordinates(currentPiece.coordinates);
            switch (direction)
            {
                case "left":
                    currentPiece.GoLeft(grid.GetGrid());
                    break;
                case "right":
                    currentPiece.GoRight(grid.GetGrid());
                    break;
                case "down":
                    currentPiece.GoDown(grid.GetGrid());
                    break;
                case "rotate":
                    currentPiece.Rotate();
                    currentPiece.CheckBorder(grid.GetGrid());
                    break;
                default:
                    break;
            }
            grid.AddPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
            form1.Refresh();
        }

        //play the soundLoop 
        public void PlaySimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.choriste);
            simpleSound.PlayLooping();
        }
    }
}
