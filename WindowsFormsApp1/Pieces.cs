using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Pieces
    {
        public abstract void CreateCoordinates(int x, System.Drawing.SolidBrush color);
        public int[,] coordinates;
        public int[,] prevCoordinates;

        public int pieceNumber;
        public System.Drawing.SolidBrush color;

        public void DisplayCoordinates()
        {
            Console.WriteLine("----------coordinates----------");
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];

                Console.WriteLine("x = " + x + " y = " +  y);
            }
        }

        public void DisplayPrevCoordinates()
        {
            Console.WriteLine("----------prev coordinates----------");
            for (int i = 0; i < prevCoordinates.GetLength(0); i++)
            {
                int x = prevCoordinates[i, 0];
                int y = prevCoordinates[i, 1];

                Console.WriteLine("x = " + x + " y = " + y);
            }
        }

        private bool PossibleGoDown()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 0] + 1 > 20)
                {
                    return false;
                }
            }
            return true;
        }

        private bool PossibleGoRight()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 1] + 1 > 9)
                {
                    return false;
                }
            }
            return true;
        }

        private bool PossibleGoLeft()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 1] - 1 < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void GoDown()
        {
            if (PossibleGoDown())
            {
                prevCoordinates = this.coordinates;
                this.DisplayPrevCoordinates();

                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 0] += 1;
                }
                this.DisplayCoordinates();
            }
        }

        public void GoRight()
        {
            if (PossibleGoRight())
            {
                prevCoordinates = coordinates;
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 1] += 1;
                }
            }
        }

        public void GoLeft()
        {
            if (PossibleGoLeft())
            {
                prevCoordinates = coordinates;
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 1] -= 1;
                }
            }
        }
    }

    public class One : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 3, x } };
            this.color = color;
        }

    }

    public class L : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { 0, x }, { 1, x }, { 2, x }, { 2, x + 1 } };
            this.color = color;
        }
    }

    public class R : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { 0, x }, { 0, x + 1 }, { 1, x }, { 1, x + 1 } };
            this.color = color;
        }
    }

    public class S : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { 0, x + 1 }, { 0, x + 2 }, { 1, x }, { 1, x + 1 } };
            this.color = color;
        }

    }

    public class T : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { 1, x + 1 }, { 0, x }, { 0, x + 1 }, { 0, x + 2 } };
            this.color = color;
        }
        
    }

}
