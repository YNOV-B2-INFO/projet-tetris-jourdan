using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{ 
    public partial class Form1 : Form
    {
        private Pieces currentPiece;
        private Pieces nextPiece;
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
            nextPiece = utils.CreatePieceObject();
            nextPiece.CreateCoordinates(position, 0, "top");
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
                if (currentPiece.canRotate(grid.GetGrid()))
                {
                    utils.Moove("rotate", currentPiece, grid, pictureBox1, this);
                    this.Refresh();
                    return true;
                }
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                if (timer1.Interval - 200 > 0)
                {
                    timer1.Interval -= 200;
                }
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                utils.Moove("left", currentPiece, grid, pictureBox1, this);
                this.Refresh();
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
                if(int.Parse(label2.Text)>1000)
                {
                    //grid.clearGrid();
                }
                grid.TestAllLines(label2);
                currentPiece = nextPiece;
                currentPiece.CreateCoordinates(4, 0, "top");
                grid.SetPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                nextPiece = utils.CreatePieceObject();
                nextPiece.CreateCoordinates(4, 0, "top");
                this.Refresh();
            }
            else
            {
                utils.Moove("down", currentPiece, grid, pictureBox1, this);
                utils.DisplayOnePiece(nextPiece, pictureBox2);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
