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
        private Grid grid = new Grid();


        Utils utils = new Utils();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void CreateNewPiece()
        {
            Random rand = new Random();
            int position = rand.Next(4, 6);

            currentPiece = utils.CreatePieceObject();
            currentPiece.CreateCoordinates(position, 0, "top");
            grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(240, 1, 1, 53);
            pictureBox2.BackColor = Color.FromArgb(240, 1, 1, 53);

        }

        private void PlayBtn_Click_1(object sender, EventArgs e)
        {

            if (!playedOnce)
            {
                CreateNewPiece();
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
            timer1.Stop();
            runing = false;
            Form2 f2 = new Form2();
            f2.ShowDialog();
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
                utils.Moove("rotate", currentPiece, grid, pictureBox1, this);
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
                utils.Moove("left", currentPiece, grid, pictureBox1, this);
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                utils.Moove("right", currentPiece, grid, pictureBox1, this);
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
            Refresh();
        }

        private void Refresh()
        {
            if (!currentPiece.PossibleGoDown(grid.GetGrid()))
            {
                int newScore = int.Parse(label2.Text) + 10;
                label2.Text = newScore.ToString();
                grid.TestAllLines();
                CreateNewPiece();
                this.Refresh();
            }
            else
            {
                utils.Moove("down", currentPiece, grid, pictureBox1, this);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             
        }
    }
}
