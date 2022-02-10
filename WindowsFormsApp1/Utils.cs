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
            int[,] coordinates = currentPiece.currentCoordinates;
            int pieceNumber = currentPiece.pieceNumber;

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int x = coordinates[i, 1];
                int y = coordinates[i, 0];

                grid[x, y] = pieceNumber;
            }
        }

        public void DisplayGrid(int[,] grid, Pieces currentPiece, PictureBox pictureBox1)
        {
            Bitmap draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics canvas = Graphics.FromImage(draw);
            int[,] coordinates = currentPiece.currentCoordinates;
            System.Drawing.SolidBrush myBrush = currentPiece.color;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] != 0)
                    {
                        canvas.FillRectangle(myBrush, i * 32,j * 32, 32, 32);
                        pictureBox1.Image = draw;
                    }
                }

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
