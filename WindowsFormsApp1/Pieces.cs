using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Pieces
    {
        public abstract void CreateCoordinates(int x, int y, String orientation);
        public int[,] prevCoordinates;
        public int[,] coordinates;
        public String orientation = "top";
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
                    if (grid[box[1], box[0]] != 0)
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

        public void Rotate()
        {
            int x = coordinates[0, 0];
            int y = coordinates[0, 1];
            String[] allOrientations = new String[] { "top", "right", "bottom", "left" };

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if ((coordinates[i, 1] < y))
                {
                    y = coordinates[i, 1];
                }

                if ((coordinates[i, 0] < x))
                {
                    x = coordinates[i, 0];
                }
            }
            String newOrientation;
            if (orientation == "left")
            {
                newOrientation = allOrientations[0];
            } else
            {
                newOrientation = allOrientations[Array.IndexOf(allOrientations, orientation) + 1];
            }
            orientation = newOrientation;
            CreateCoordinates(x, y, newOrientation);
            
        }

        public void CheckBorder()
        {
            int x = coordinates[0, 0];
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 0] > 0)
                {
                    x = coordinates[i, 0];
                }
            }
            if (x > 9)
            {
                this.GoLeft();
            }
        }
    }

    public class One : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            switch (orientation)
            {
                case "top":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x, y+2 },
                        { x, y+3 }
                    };
                    break;

                case "right":
                    coordinates = new int[,] {
                        { x-1, y+2 },
                        { x, y+2 },
                        { x+1, y+2 },
                        { x+2, y+2 }
                    };
                    break;

                case "bottom":
                    coordinates = new int[,] {
                       { x+1, y },
                        { x+1, y+1 },
                        { x+1, y+2 },
                        { x+1, y+3 }
                    };
                    break;

                case "left":
                    coordinates = new int[,] {
                        { x-1, y+1 },
                        { x, y+1 },
                        { x+1, y+1 },
                        { x+2, y+1 }
                    };
                    break;
            }
                    this.color = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        }

    }

    public class L : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {

            switch (orientation)
            {
                case "top":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x, y+2 },
                        { x+1, y+2 }
                    };
                    break;

                case "right":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y },
                        { x+2, y }
                    };
                    break;

                case "bottom":
                    coordinates = new int[,] {
                        { x+1, y },
                        { x+1, y+1 },
                        { x+1, y+2 },
                        { x, y }
                    };
                    break;

                case "left":
                    coordinates = new int[,] {
                        { x, y+2 },
                        { x+1, y+2 },
                        { x+2, y+2 },
                        { x+2, y+1 }
                    };
                    break;
            }
            this.color = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        }
    }

    public class R : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            switch (orientation)
            {
                case "top":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y },
                        { x+1, y+1 }
                    };
                    break;

                case "right":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y },
                        { x+1, y+1 }
                    };
                    break;

                case "bottom":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y },
                        { x+1, y+1 }
                    };
                    break;

                case "left":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y },
                        { x+1, y+1 }
                    };
                    break;
            }
            this.color = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        }
    }

    public class S : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            switch (orientation)
            {
                case "top":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y+1 },
                        { x+1, y+2 }
                    };
                    break;

                case "right":
                    coordinates = new int[,] {
                        { x+1, y },
                        { x+2, y },
                        { x, y+1 },
                        { x+1, y+1 }
                    };
                    break;

                case "bottom":
                    coordinates = new int[,] {
                        { x, y },
                        { x, y+1 },
                        { x+1, y+1 },
                        { x+1, y+2 }
                    };
                    break;

                case "left":
                    coordinates = new int[,] {
                        { x+1, y },
                        { x+2, y },
                        { x, y+1 },
                        { x+1, y+1 }
                    };
                    break;
            }
            this.color = new System.Drawing.SolidBrush(System.Drawing.Color.Silver);
        }

    }

    public class T : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            switch (orientation)
            {
                case "top":
                    coordinates = new int[,] 
                    {
                        { x+1, y },
                        { x, y+1 },
                        { x+1, y+1 },
                        { x+2, y+1 }
                    };
                    break;

                case "right":
                    coordinates = new int[,] 
                    {
                        { x+1, y },
                        { x+1, y+1 },
                        { x+1, y+2 },
                        { x+2, y+1 }
                    };
                    break;

                case "bottom":
                    coordinates = new int[,] 
                    {
                        { x+1, y+2 },
                        { x, y+1 },
                        { x+1, y+1 },
                        { x+2, y+1 }
                    };
                    break;

                case "left":
                    coordinates = new int[,] 
                    {
                        { x+1, y },
                        { x+1, y+1 },
                        { x+1, y+2 },
                        { x, y+1 }
                    };
                    break;
            }
            this.color = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
        }
    }
}
