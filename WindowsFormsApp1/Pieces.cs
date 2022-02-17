using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Pieces
    {
        //declare the abstract functions here
        public abstract void CreateCoordinates(int x, int y, String orientation);
        public abstract void GetHitboxCoordinates();

        //declare the global vars here 
        public int[,] prevCoordinates;
        public int[,] coordinates;
        public int pieceNumber;
        public String orientation = "top";
        public int[,] hitboxLeft;
        public int[,] hitboxBottom = new int[,] { };
        public int[,] hitboxRight;
        public System.Drawing.SolidBrush color;

        //check if the piece can go down,
        //based on the hitbox and the size of the grid 
        public bool PossibleGoDown(int[,] grid)
        {
            this.GetHitboxCoordinates();
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 1] + 1 >= 20)
                {
                    return false;
                }

            }
            for (int i = 0; i < hitboxBottom.GetLength(0); i++)
            {
                if (hitboxBottom[i, 1] < 20)
                {
                    if (grid[hitboxBottom[i, 1], hitboxBottom[i, 0]] != 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        //check if the piece can go right,
        //based on the hitbox and the size of the grid 
        private bool PossibleGoRight(int[,] grid)
        {
            this.GetHitboxCoordinates();
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 0] + 1 > 9)
                {
                    return false;
                }
            }

            for (int i = 0; i < hitboxRight.GetLength(0); i++)
            {
                if (hitboxRight[i, 1] < 20)
                {
                    if (grid[hitboxRight[i, 1], hitboxRight[i, 0]] != 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        //check if the piece can go Left,
        //based on the hitbox and the size of the grid 
        private bool PossibleGoLeft(int[,] grid)
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 0] - 1 < 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < hitboxLeft.GetLength(0); i++)
            {
                if (hitboxLeft[i, 1] < 20)
                {
                    if (grid[hitboxLeft[i, 1], hitboxLeft[i, 0]] != 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        //make the piece go down if there is nothing on the road 
        public void GoDown(int[,] grid)
        {
            this.GetHitboxCoordinates();
            if (PossibleGoDown(grid))
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 1] += 1;
                }
            }
        }

        //make the piece go right if there is nothing on the road 
        public void GoRight(int[,] grid)
        {
            this.GetHitboxCoordinates();
            if (PossibleGoRight(grid))
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 0] += 1;
                }
            }
        }

        //make the piece go left if there is nothing on the road 
        public void GoLeft(int[,] grid)
        {
            this.GetHitboxCoordinates();
            if (PossibleGoLeft(grid))
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    coordinates[i, 0] -= 1;
                }
            }
        }

        //rotate the piece 
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
            }
            else
            {
                newOrientation = allOrientations[Array.IndexOf(allOrientations, orientation) + 1];
            }
            orientation = newOrientation;
            CreateCoordinates(x, y, newOrientation);
        }

        //check if the piece can rotate
        public bool CanRotate(int[,] grid)
        {

            int x = coordinates[0, 0];
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (coordinates[i, 0] > 0)
                {
                    x = coordinates[i, 0];
                }
            }
            if (x < 9 && x > 0)
            {
                if (PossibleGoRight(grid))
                {
                    return true;
                }
            }
            return false;
        }

        //check if the piece is too close to the border 
        public void CheckBorder(int[,] grid)
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
                this.GoLeft(grid);
            }
        }
    }

    public class One : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            this.orientation = orientation;
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
                        { x-1, y },
                        { x, y },
                        { x+1, y },
                        { x+2, y }
                    };
                    break;
            }
            this.color = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        }

        public override void GetHitboxCoordinates()
        {

            int x = coordinates[0, 0];
            int y = coordinates[0, 1];

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

            switch (this.orientation)
            {
                case "top":
                case "bottom":
                    this.hitboxLeft = new int[,] {
                        { x-1, y },
                        { x-1, y+1 },
                        { x-1, y+2 },
                        { x-1, y+3 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+4 }
                    };
                    hitboxRight = new int[,] {
                        { x+1, y },
                        { x+1, y+1 },
                        { x+1, y+2 },
                        { x+1, y+3 }
                    };
                    break;
                case "right":
                case "left":
                    hitboxLeft = new int[,] {
                        { x-1, y }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+1 },
                        { x+1, y+1 },
                        { x+2, y+1 },
                        { x+3, y+1 }
                    };
                    hitboxRight = new int[,] {
                        { x+4, y }
                    };
                    break;
            }
        }
    }

    public class L : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            this.orientation = orientation;

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

        public override void GetHitboxCoordinates()
        {
            int x = coordinates[0, 0];
            int y = coordinates[0, 1];

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

            switch (this.orientation)
            {
                case "top":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x-1, y+1 },
                        { x-1, y+2 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+3 },
                        { x+1, y+3 }
                    };
                    hitboxRight = new int[,] {
                        { x+1, y },
                        { x+1, y+1 },
                        { x+2, y+2 }
                    };
                    break;
                case "right":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x-1, y+1 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+1 },
                        { x+2, y+1 }
                    };
                    hitboxRight = new int[,] {
                        { x+1, y+1 },
                        { x+3, y }
                    };
                    break;
                case "bottom":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x, y+1 },
                        { x, y+2 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+1 },
                        { x+1, y+3 }
                    };
                    hitboxRight = new int[,] {
                        { x+2, y },
                        { x+2, y+1 },
                        { x+2, y+2 }
                    };
                    break;
                case "left":
                    hitboxLeft = new int[,] {
                        { x-1, y+1 },
                        { x+1, y }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+2 },
                        { x+2, y+2 }
                    };
                    hitboxRight = new int[,] {
                        { x+3, y },
                        { x+3, y+1 }
                    };
                    break;
            }
        }
    }

    public class R : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            this.orientation = orientation;

            switch (orientation)
            {
                case "top":
                case "right":
                case "bottom":
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

        public override void GetHitboxCoordinates()
        {
            int x = coordinates[0, 0];
            int y = coordinates[0, 1];

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

            switch (this.orientation)
            {
                case "top":
                case "right":
                case "bottom":
                case "left":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x-1, y+1 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+2 }
                    };
                    hitboxRight = new int[,] {
                        { x+2, y },
                        { x+2, y+1 }
                    };
                    break;
            }
        }
    }

    public class S : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            this.orientation = orientation;

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

        public override void GetHitboxCoordinates()
        {
            int x = coordinates[0, 0];
            int y = coordinates[0, 1];

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

            switch (this.orientation)
            {
                case "top":
                case "bottom":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x-1, y+1 },
                        { x, y+2 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+3 }
                    };
                    hitboxRight = new int[,] {
                        { x+1, y },
                        { x+2, y+1 },
                        { x+2, y+2 }
                    };
                    break;

                case "right":
                case "left":
                    hitboxLeft = new int[,] {
                        { x, y },
                        { x-1, y+1 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+2 },
                        { x+2, y+1 }
                    };
                    hitboxRight = new int[,] {
                        { x+3, y },
                        { x+2, y+1 }
                    };
                    break;
            }
        }
    }

    public class T : Pieces
    {
        public override void CreateCoordinates(int x, int y, String orientation)
        {
            this.orientation = orientation;

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

        public override void GetHitboxCoordinates()
        {
            int x = coordinates[0, 0];
            int y = coordinates[0, 1];

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

            switch (this.orientation)
            {
                case "top":
                    hitboxLeft = new int[,] {
                        { x, y },
                        { x-1, y+1 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+2 },
                        { x+2, y+2 }
                    };
                    hitboxRight = new int[,] {
                        { x+2, y },
                        { x+3, y+1 }
                    };
                    break;
                case "right":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x-1, y+1 },
                        { x-1, y+2 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+3 },
                        { x+1, y+2 }
                    };
                    hitboxRight = new int[,] {
                        { x+1, y },
                        { x+2, y+1 },
                        { x+1, y+2 }
                    };
                    break;
                case "bottom":
                    hitboxLeft = new int[,] {
                        { x-1, y },
                        { x, y+1 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+1 },
                        { x+1, y+2 },
                        { x+2, y+1 }
                    };
                    hitboxRight = new int[,] {
                        { x+3, y },
                        { x+2, y+1 }
                    };
                    break;
                case "left":
                    hitboxLeft = new int[,] {
                        { x, y },
                        { x-1, y+1 },
                        { x, y+2 }
                    };
                    hitboxBottom = new int[,] {
                        { x, y+2 },
                        { x+1, y+3 }
                    };
                    hitboxRight = new int[,] {
                        { x+2, y },
                        { x+2, y+1 },
                        { x+2, y+2 }
                    };
                    break;
            }
        }
    }
}
