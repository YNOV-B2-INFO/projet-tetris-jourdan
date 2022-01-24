using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Pieces
    {
        public abstract int[,] CreatePiece(int x);
        public int[,] coordinates;

        public void goDown()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                coordinates[i, 1] += 1;
            }
        }
    }

    public class One : Pieces
    {
        public override int[,] CreatePiece(int x)
        {
            coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 3, x } };
            return coordinates;
        }

    }

    public class L : Pieces
    {
        public override int[,] CreatePiece(int x)
        {
            coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 2, x + 1 } };
            return coordinates;
        }
    }

    public class R : Pieces
    {
        public override int[,] CreatePiece(int x)
        {
            coordinates = new int[,] { { 0, x }, { 0, x + 1 }, { 1, x }, { 1, x + 1 } };
            return coordinates;
        }
    }

    public class S : Pieces
    {
        public override int[,] CreatePiece(int x)
        {
            coordinates = new int[,] { { 0, x + 1 }, { 0, x + 2 }, { 1, x }, { 1, x + 1 } };
            return coordinates;
        }

    }

    public class T : Pieces
    {
        public override int[,] CreatePiece(int x)
        {
            coordinates = new int[,] { { 1, x + 1 }, { 0, x }, { 0, x + 1 }, { 0, x + 2 } };
            return coordinates;
        }
        
    }

}
