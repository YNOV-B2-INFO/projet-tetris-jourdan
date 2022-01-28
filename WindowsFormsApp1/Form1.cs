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
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Run()
        {
            

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
            Run();
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {            
            Console.WriteLine("test");
            int[,] grid = new int[20, 10];
            List<Pieces> allPieces = new List<Pieces>();
            Utils utils = new Utils();
            utils.Create_Piece(grid, allPieces);
            utils.displayGrid(grid);

            int[,] coordinates = allPieces[0].coordinates;
            System.Drawing.SolidBrush myBrush = utils.GenerateBrush();


            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                e.Graphics.FillRectangle(myBrush, coordinates[i, 1] * 32, coordinates[i, 0] * 32, 32, 32);
            }
        }
    }
}
