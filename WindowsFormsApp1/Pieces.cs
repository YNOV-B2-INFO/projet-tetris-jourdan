using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Pieces
    {
        public abstract void CreateCoordinates(int x);
        public int[,] coordinates;
        public int pieceNumber;

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
        public override void CreateCoordinates(int x)
        {
            coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 3, x } };
        }

    }

    public class L : Pieces
    {
        public override void CreateCoordinates(int x)
        {
            coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 2, x + 1 } };
        }
    }

    public class R : Pieces
    {
        public override void CreateCoordinates(int x)
        {
            coordinates = new int[,] { { 0, x }, { 0, x + 1 }, { 1, x }, { 1, x + 1 } };
        }
    }

    public class S : Pieces
    {
        public override void CreateCoordinates(int x)
        {
            coordinates = new int[,] { { 0, x + 1 }, { 0, x + 2 }, { 1, x }, { 1, x + 1 } };
        }

    }

    public class T : Pieces
    {
        public override void CreateCoordinates(int x)
        {
            coordinates = new int[,] { { 1, x + 1 }, { 0, x }, { 0, x + 1 }, { 0, x + 2 } };
        }
        
    }

}
