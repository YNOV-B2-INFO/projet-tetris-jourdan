using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Pieces
    {
        public abstract void CreateCoordinates(int x, int y, System.Drawing.SolidBrush color);
        public int[][,] coordinates;
        public int[,] currentCoordinates;

        public int pieceNumber;
        public System.Drawing.SolidBrush color;

        private bool PossibleGoDown()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (currentCoordinates[i, 0] + 1 > 20)
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
                if (currentCoordinates[i, 1] + 1 > 9)
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
                if (currentCoordinates[i, 1] - 1 < 0)
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
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    currentCoordinates[i, 0] += 1;
                }
            }
        }

        public void GoRight()
        {
            if (PossibleGoRight())
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    currentCoordinates[i, 1] += 1;
                }
            }
        }

        public void GoLeft()
        {
            if (PossibleGoLeft())
            {
                for (int i = 0; i < coordinates.GetLength(0); i++)
                {
                    currentCoordinates[i, 1] -= 1;
                }
            }
        }
    }

    public class One : Pieces
    {
        public override void CreateCoordinates(int x, int y, System.Drawing.SolidBrush color)
        {

            coordinates = new int[][,]
            {
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x, y+2 },
                    { x, y+3 }
                }/*,
                new int[,]
                {
                    { x-1, y+2 },
                    { x, y+2 },
                    { x+1, y+2 },
                    { x+2, y+2 }
                },
                new int[,]
                {
                    { x+1, y },
                    { x+1, y+1 },
                    { x+1, y+2 },
                    { x+1, y+3 }
                },
                new int[,]
                {
                    { x-1, y+1 },
                    { x, y+1 },
                    { x+1, y+1 },
                    { x+2, y+1 }
                }*/
            };
            currentCoordinates = coordinates[0];


            this.color = color;
        }

    }

    public class L : Pieces
    {
        public override void CreateCoordinates(int x, int y, System.Drawing.SolidBrush color)
        {
            coordinates = new int[][,]
            {
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x, y+2 },
                    { x+1, y+2 }
                }/*,
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y },
                    { x+2, y }
                },
                new int[,]
                {
                    { x+1, y },
                    { x+2, y },
                    { x+3, y+1 },
                    { x+3, y+2 }
                },
                new int[,]
                {
                    { x, y+2 },
                    { x+1, y+2 },
                    { x+2, y+2 },
                    { x+2, y+1 }
                }*/
            };
            currentCoordinates = coordinates[0];
            this.color = color;
        }
    }

    public class R : Pieces
    {
        public override void CreateCoordinates(int x, int y, System.Drawing.SolidBrush color)
        {
            coordinates = new int[][,]
            {
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y },
                    { x+1, y+1 }
                }/*,
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y },
                    { x+1, y+1 }
                },
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y },
                    { x+1, y+1 }
                },
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y },
                    { x+1, y+1 }
                }*/
            };
            currentCoordinates = coordinates[0];
            this.color = color;
        }
    }

    public class S : Pieces
    {
        public override void CreateCoordinates(int x, int y, System.Drawing.SolidBrush color)
        {
            coordinates = new int[][,]
            {
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y+1 },
                    { x+1, y+2 }
                }/*,
                new int[,]
                {
                    { x+1, y },
                    { x+2, y },
                    { x, y+1 },
                    { x+1, y+1 }
                },
                new int[,]
                {
                    { x, y },
                    { x, y+1 },
                    { x+1, y+1 },
                    { x+1, y+2 }
                },
                new int[,]
                {
                    { x+1, y },
                    { x+2, y },
                    { x, y+1 },
                    { x+1, y+1 }
                }*/
            };
            currentCoordinates = coordinates[0];
            this.color = color;
        }

    }

    public class T : Pieces
    {
        public override void CreateCoordinates(int x, int y, System.Drawing.SolidBrush color)
        {
            coordinates = new int[][,]
            {
                new int[,]
                {
                    { x+1, y },
                    { x, y+1 },
                    { x+1, y+1 },
                    { x+2, y+1 }
                }/*,
                new int[,]
                {
                    { x+1, y },
                    { x+1, y+1 },
                    { x+1, y+2 },
                    { x+2, y+1 }
                },
                new int[,]
                {
                    { x+1, y+2 },
                    { x, y+1 },
                    { x+1, y+1 },
                    { x+2, y+1 }
                },
                new int[,]
                {
                    { x+1, y },
                    { x+1, y+1 },
                    { x+1, y+2 },
                    { x, y+1 }
                }*/
            };
            currentCoordinates = coordinates[0];
            this.color = color;
        }

    }

}
