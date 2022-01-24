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
    public partial class Form1 : Form
    {
        bool isPlaying = false;
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Run()
        {
            int[,] grid = new int[20, 10];
            List<Pieces> allPieces = new List<Pieces>();
            Utils utils = new Utils();
            utils.Create_Piece(grid, allPieces);
            utils.displayGrid(grid);

            
            

            Bitmap bmp = new Bitmap(32, 32);
            Graphics g = Graphics.FromImage(bmp);
            foreach (var piece in grid)
            {
                switch (piece)
                {
                    case 1:
                        SolidBrush bRed = new SolidBrush(Color.Red);
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                g.FillRectangle(bRed, new Rectangle(i * 32, j * 32, 32, 32));
                                pictureBox1.Controls.Add(g);
                            }
                        }
                        break;
                    case 2:
                        SolidBrush bWhite = new SolidBrush(Color.White);
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                g.FillRectangle(bWhite, new Rectangle(i * 32, j * 32, 32, 32));
                                pictureBox1.Controls.Add(g);
                            }
                        }
                        break;
                    case 3:
                        SolidBrush bBlue = new SolidBrush(Color.Blue);
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                g.FillRectangle(bBlue, new Rectangle(i * 32, j * 32, 32, 32));
                                pictureBox1.Controls.Add(g);
                            }
                        }
                        break;
                    case 4:
                        SolidBrush bPurple = new SolidBrush(Color.Purple);
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                g.FillRectangle(bPurple, new Rectangle(i * 32, j * 32, 32, 32));
                                pictureBox1.Controls.Add(g);

                            }
                        }
                        break;
                    case 5:
                        SolidBrush bPink = new SolidBrush(Color.Pink);
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                g.FillRectangle(bPink, new Rectangle(i * 32, j * 32, 32, 32));
                                pictureBox1.Controls.Add(g);

                            }
                        }
                        break;
                    default:
                        SolidBrush bTransparent = new SolidBrush(Color.Transparent);
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                g.FillRectangle(bTransparent, new Rectangle(i * 32, j * 32, 32, 32));
                                pictureBox1.Controls.Add(g);

                            }
                        }
                        break;
                }
            }

/*           for (int i = 0; i < 500; i += 20)
             {
                allPieces[allPieces.Count() - 1].goDown();
                Thread.Sleep(500);
                t.Refresh();
            }
*/
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void PlayBtn_Click_1(object sender, EventArgs e)
        {
            switch (isPlaying)
            {
                case true:
                    isPlaying = false;
                    break;

                case false:
                    isPlaying = true;
                    Run();
                    break;
            }
        }

        private void OptionBtn_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("You pressed OPTION btn");

        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //retrieve the chars here 
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                Console.WriteLine("You pressed Up arrow key");

                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                Console.WriteLine("You pressed Down arrow key");
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                Console.WriteLine("You pressed Left arrow key");
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                Console.WriteLine("You pressed Right arrow key");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
