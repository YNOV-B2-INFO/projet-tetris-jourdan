using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlayBtn_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("play");
        }

        private void OptionBtn_Click_1(object sender, EventArgs e)
        {
            //this.Hide();

        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }
    }
}
