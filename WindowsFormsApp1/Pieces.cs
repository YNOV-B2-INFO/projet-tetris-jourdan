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
        public int[,] prevCoordinates;
        public int[,] coordinates;

        public int pieceNumber;
        public System.Drawing.SolidBrush color;

        public void DisplayCoordinates()
        {
            Console.WriteLine("----------coordinates----------");
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];

                Console.WriteLine("x = " + x + " y = " + y);
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

       /*public bool PossibleGoDown(int[,] grid)
        {
            List<int[]> hitbox = getHitbox();
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 1] + 1 >= 20)
                {
                    return false;
                }
            }
            return true;
        }*/
        
        public bool PossibleGoDown(int[,] grid)
        {
            List<int[]> hitbox = getHitbox();
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 1] + 1 >= 20)
                {
                    return false;
                }
                foreach (int[] box in hitbox)
                {
                    if (grid[box[0], box[1]] != 0) 
                    {
                         return false;
                    }
                }
            }
            return true;
        }

        private List<int[]> getHitbox()
        {
            List<int[]> hitbox = new List<int[]>();
            int previousY = 0;

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int y = coordinates[i, 1];
                if (y > previousY)
                {
                    previousY = y;
                }
            }
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                int y = coordinates[i, 1];
                int x = coordinates[i, 0];
                if (y == previousY && y < 19)
                {
                    hitbox.Add(new int[] { x, y + 1 });
                }
            }
            return hitbox;
        }


        private bool PossibleGoRight()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 0] + 1 > 9)
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
                if (coordinates[i, 0] - 1 < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void GoDown(int[,] grid)
        {
            if (PossibleGoDown(grid))
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 1] += 1;
                }
            } 
        }

        public void GoRight()
        {
            if (PossibleGoRight())
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 0] += 1;
                }
            }
        }

        public void GoLeft()
        {
            if (PossibleGoLeft())
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 0] -= 1;
                }
            }
        }
    }

    public class One : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { x, 0 }, { x, 1 }, { x, 2 }, { x, 3 } };
            this.color = color;
        }

    }

    public class L : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { x, 0 }, { x, 1 }, { x, 2 }, { x + 1, 2} };
            this.color = color;
        }
    }

    public class R : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { x, 0 }, { x + 1, 1 }, { x, 1 }, { x + 1, 0 } };
            this.color = color;
        }
    }

    public class S : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { x, 0 }, { x , 1 }, { x + 1, 1 }, { x + 2, 1 } };
            this.color = color;
        }

    }

    public class T : Pieces
    {
        public override void CreateCoordinates(int x, System.Drawing.SolidBrush color)
        {
            coordinates = new int[,] { { x + 1, 0 }, { x, 1 }, { x + 1 , 1}, { x + 2, 1 } };
            this.color = color;
        }
        
    }

}
