using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public abstract class Piece
    {
        public abstract int[,] CreatePiece(int x);
        
    }

    public class One : Piece
    {
        public override int[,] CreatePiece(int x)
        {
            int[,] coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 3, x } };
            return coordinates;
        }

    }

    public class L : Piece
    {
        public override int[,] CreatePiece(int x)
        {
            int[,] coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 2, x + 1 } };
            return coordinates;
        }
    }

    public class R : Piece
    {
        public override int[,] CreatePiece(int x)
        {
            int[,] coordinates = new int[,] { { 0, x }, { 0, x + 1 }, { 1, x }, { 1, x + 1 } };
            return coordinates;
        }
    }

    public class S : Piece
    {
        public override int[,] CreatePiece(int x)
        {
            int[,] coordinates = new int[,] { { 0, x + 1 }, { 0, x + 2 }, { 1, x }, { 1, x + 1 } };
            return coordinates;
        }

    }

    public class T : Piece
    {
        public override int[,] CreatePiece(int x)
        {
            int[,] coordinates = new int[,] { { 1, x + 1 }, { 0, x }, { 0, x + 1 }, { 0, x + 2 } };
            return coordinates;
        }

    }
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }
    }
}
