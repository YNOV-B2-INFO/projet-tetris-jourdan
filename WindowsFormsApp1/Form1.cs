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
        public Pieces currentPiece;
        Utils utils = new Utils();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private async void Run()
        {
            int[,] grid = new int[20, 10];
            Random rand = new Random();
            int position = rand.Next(0, 9);


            
            currentPiece = utils.CreatePieceObject();
            currentPiece.CreateCoordinates(position, utils.GenerateBrush());
            utils.AddPieceInGrid(currentPiece, grid);
            //utils.DisplayGrid(grid)
            
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void PlayBtn_Click_1(object sender, EventArgs e)
        {
            Run();
            timer1.Start();

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
                timer1.Interval -= 450;
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                Console.WriteLine("You pressed Left arrow key");
                currentPiece.GoLeft();

                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                Console.WriteLine("You pressed Right arrow key");
                currentPiece.GoRight();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            utils.DisplayPieceGraphics(currentPiece, pictureBox1);
            currentPiece.GoDown();
            this.Refresh();
        }
    }
}
