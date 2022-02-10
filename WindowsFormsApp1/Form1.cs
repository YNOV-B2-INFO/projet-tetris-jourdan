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
        private Pieces currentPiece;
        private bool runing = false;
        private bool playedOnce = false;
        int[,] grid = new int[10, 20];

        Utils utils = new Utils();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private async void Run()
        {
            Random rand = new Random();
            int position = rand.Next(0, 9);

            currentPiece = utils.CreatePieceObject();
            currentPiece.CreateCoordinates(position, utils.GenerateBrush());
            utils.AddPieceInGrid(currentPiece, grid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlayBtn_Click_1(object sender, EventArgs e)
        {
            if (!playedOnce)
            {
                Run();
                playedOnce = true;
            }

            if (!runing)
            {
                timer1.Start();
                runing = true;
            }
            else
            {
                timer1.Stop();
                runing = false;
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
                if (timer1.Interval - 450 > 0)
                {
                    timer1.Interval -= 450;
                }
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                utils.DisplayGridGraphics(currentPiece, grid, pictureBox1);
                currentPiece.prevCoordinates = currentPiece.coordinates;
                utils.RemovePrevCoordinates(currentPiece, grid);
                currentPiece.GoLeft();
                utils.UpdateGrid(currentPiece, grid);
                this.Refresh();
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                utils.DisplayGridGraphics(currentPiece, grid, pictureBox1);
                currentPiece.prevCoordinates = currentPiece.coordinates;
                utils.RemovePrevCoordinates(currentPiece, grid);
                currentPiece.GoRight();
                utils.UpdateGrid(currentPiece, grid);
                this.Refresh();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {            
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            refresh(); 
        }

        private void refresh()
        {
            utils.DisplayGridGraphics(currentPiece, grid, pictureBox1);
            currentPiece.prevCoordinates = currentPiece.coordinates;
            utils.RemovePrevCoordinates(currentPiece, grid);
            currentPiece.GoDown();
            Console.WriteLine("CA RENTRE");
            utils.UpdateGrid(currentPiece, grid);
            this.Refresh();
        }
    }
}
