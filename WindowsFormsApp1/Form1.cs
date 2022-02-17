using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{ 
    public partial class Form1 : Form
    {
        //declare all global vars here 
        private Pieces currentPiece;
        private Pieces nextPiece;
        private bool playedOnce = false;
        private Grid grid = new Grid();
        Utils utils = new Utils();
        private bool notCleared = true;

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        //create currentPiece object and its coordinates  / nextPiece object and its coordinates  
        //add currentPiece in the grid 
        private void CreateNewPiece()
        {
            //generate random position 
            Random rand = new Random();
            int position = rand.Next(4, 6);

            currentPiece = utils.CreatePieceObject();
            currentPiece.CreateCoordinates(position, 0, "top");
            nextPiece = utils.CreatePieceObject();
            nextPiece.CreateCoordinates(position, 0, "top");
            grid.AddPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
        }

        //when the form1 is loaded it sets the background of both picturebox and label
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(240, 1, 1, 53);
            pictureBox2.BackColor = Color.FromArgb(240, 1, 1, 53);
            label2.BackColor = Color.FromArgb(240, 1, 1, 53);
        }

        //manage the playBtn (play pause)
        private void PlayBtn_Click_1(object sender, EventArgs e)
        {
            if (!playedOnce)
            {
                CreateNewPiece();
                playedOnce = true;
                label2.Text = "0";
            }

            if (PlayBtn.Text == "PLAY")
            {
                timer1.Start();
                PlayBtn.Text = "PAUSE";
            }
            else
            {
                timer1.Stop();
                PlayBtn.Text = "PLAY";
            }

        }

        //pause the game and display option menu 
        private void OptionBtn_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            PlayBtn.Text = "PLAY";
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        //quit the game when quit is pressed
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //manage arrow keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if key up and the piece can rotate 
            //rotate the piece and refresh 
            if (keyData == Keys.Up)
            {
                if (currentPiece.CanRotate(grid.GetGrid()))
                {
                    utils.Moove("rotate", currentPiece, grid, pictureBox1, this);
                    this.Refresh();
                    return true;
                }
            }

            //if key left and the piece can go left 
            //moove left the piece and refresh 
            if (keyData == Keys.Left)
            {
                utils.Moove("left", currentPiece, grid, pictureBox1, this);
                this.Refresh();
                return true;
            }

            //if key right and the piece can go right 
            //moove right the piece and refresh 
            if (keyData == Keys.Right)
            {
                utils.Moove("right", currentPiece, grid, pictureBox1, this);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //each timer tick, refresh the page 
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //check if the piece is in place,
            //increase the score, 
            //if the score > 1000 clear the grid 
            //create the new piece,
            //refresh 
            //else moove the piece down 

            //si piece posée et ligne du haut de la grid pas que des 0 -> game over 
            if (!currentPiece.PossibleGoDown(grid.GetGrid()))
            {
                //update the score
                int newScore = int.Parse(label2.Text) + 10;
                label2.Text = newScore.ToString();

                //clear the grid 
                if(int.Parse(label2.Text)>1000 && notCleared)
                {
                    grid.ClearGrid();
                    notCleared = true;
                }

                //if the topline isnt empty,
                //gameover 
                if (!grid.IsLineEmpty(0))
                {
                    timer1.Stop();
                    currentPiece = null;
                    playedOnce = false;
                    grid.ClearGrid();
                    utils.DisplayGridGraphics(grid.GetGrid(), pictureBox1);
                    PlayBtn.Text = "PLAY";
                    Form3 f3 = new Form3();
                    f3.ShowDialog();

                } 
                //generate new piece 
                else
                {
                    grid.TestAllLines(label2);
                    currentPiece = nextPiece;
                    currentPiece.CreateCoordinates(4, 0, "top");
                    grid.AddPieceWithCoordinates(currentPiece.coordinates, currentPiece.pieceNumber);
                    nextPiece = utils.CreatePieceObject();
                    nextPiece.CreateCoordinates(4, 0, "top");

                }


                this.Refresh();
            }
            //make the piece go down 
            else
            {
                utils.Moove("down", currentPiece, grid, pictureBox1, this);
                utils.DisplayOnePiece(nextPiece, pictureBox2);
            }
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

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
