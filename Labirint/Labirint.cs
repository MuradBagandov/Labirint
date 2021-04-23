using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    public struct LabirintBlock
    {
        public bool Left, Right, Top, Bottom;
        public bool IsVisit;

        //public bool HaveDirectionsMovement()
        //{
        //    if (!Left)
        //}

        public LabirintBlock(bool left, bool right, bool top, bool bottom, bool isVisit)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
            IsVisit = isVisit;
        }
    }

    public class Labirint
    {
        public int Width { get; set; }
        public int Height { get; set; }

        


        public void Generate()
        {
            
            LabirintBlock[,] labirintArray = new LabirintBlock[Width, Height];

            Stack<(int row, int column)> visitBlocks = new Stack<(int row, int column)>();

            (int row, int column) currentPosition = (0, 0);


            while (true)
            {
                LabirintBlock currentBlock = labirintArray[currentPosition.row, currentPosition.column];

                if ((currentPosition.row > 0 && labirintArray[currentPosition.row - 1, currentPosition.column].IsVisit == false))
                {
                    if (currentBlock.Left == true)
                    {
                        currentBlock.Left = false;
                        currentPosition.row -= 1;
                    }
                        
                }
                else if ((currentPosition.row > 0 && labirintArray[currentPosition.row + 1, currentPosition.column].IsVisit == false))
                {
                    currentPosition.row += 1;
                }
                else if ((currentPosition.column > 0 && labirintArray[currentPosition.row, currentPosition.column-1].IsVisit == false))
                {
                    currentPosition.column -= 1;
                }
                else if ((currentPosition.column > 0 && labirintArray[currentPosition.row, currentPosition.column+1].IsVisit == false))
                {
                    currentPosition.column += 1;
                }


            }



        }



    }
}
