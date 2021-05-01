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

        public LabirintBlock[,] labirintArray;

        private Random _Random;

        public (int row, int column) currentPosition = (0, 0);

        public Labirint() : this (5,5){}

        public Labirint(int width, int height)
        {
            Width = width;
            Height = height;
            _Random = new Random();
        }

        public async void Generate()
        {
            LabirintArrayInit();

            Stack<(int row, int column)> visitBlocks = new Stack<(int row, int column)>();

            while (true)
            {
                //await Task.Delay(1);
                LabirintBlock currentBlock = labirintArray[currentPosition.row, currentPosition.column];

                labirintArray[currentPosition.row, currentPosition.column].IsVisit = true;
                var dirs = GetAccessDirection(currentPosition);

                if (dirs == null || dirs.Count == 0)
                {
                    if (visitBlocks.Count > 0)
                        currentPosition = visitBlocks.Pop();
                    else
                        break;
                }
                else
                {
                    visitBlocks.Push(currentPosition);

                    var nextPosition = GetRandomDirection(dirs);

                    if (nextPosition.row != currentPosition.row)
                    {
                        if (nextPosition.row < currentPosition.row)
                        {
                            labirintArray[currentPosition.row, currentPosition.column].Bottom = false;
                            labirintArray[nextPosition.row, nextPosition.column].Top = false;
                        }
                        else
                        {
                            labirintArray[currentPosition.row, currentPosition.column].Top = false;
                            labirintArray[nextPosition.row, nextPosition.column].Bottom = false;
                        }
                            
                    }
                    if (nextPosition.column != currentPosition.column)
                    {
                        if (nextPosition.column > currentPosition.column)
                        {
                            labirintArray[currentPosition.row, currentPosition.column].Right = false;
                            labirintArray[nextPosition.row, nextPosition.column].Left = false;
                        }
                        else
                        {
                            labirintArray[currentPosition.row, currentPosition.column].Left = false;
                            labirintArray[nextPosition.row, nextPosition.column].Right = false;
                        }       
                    }
                    currentPosition = nextPosition;
                }
            }
        }


        private List<(int row, int column)> GetAccessDirection((int row, int column) position)
        {
            List<(int row, int column)> returnList = new List<(int row, int column)>();
            LabirintBlock currentBlock = labirintArray[position.row, position.column];

            if (CheckBlock(position.row - 1, position.column) && currentBlock.Bottom == true)
                returnList.Add((position.row - 1, position.column));
            if (CheckBlock(position.row + 1, position.column) && currentBlock.Top == true)
                returnList.Add((position.row + 1, position.column));
            if (CheckBlock(position.row, position.column - 1) && currentBlock.Left == true)
                returnList.Add((position.row, position.column - 1));
            if (CheckBlock(position.row, position.column + 1) && currentBlock.Right == true)
                returnList.Add((position.row, position.column + 1));

            return returnList;
        }


        private (int row, int column) GetRandomDirection(List<(int row, int column)> dirs)
        {
            if (dirs == null || dirs.Count == 0)
                throw new ArgumentException();

            double r = _Random.NextDouble();
            double magnitude = 1.0 / dirs.Count;

            double sum = 0;
            foreach ((int row, int column) item in dirs)
            {
                sum += magnitude;
                if (sum >= r)
                    return item;
            }
            throw new ArgumentException();
        }

        private bool CheckBlock(int row, int column)
        {
            try
            {
                if (labirintArray[row, column].IsVisit == true)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }


        private void LabirintArrayInit()
        {
            labirintArray = new LabirintBlock[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    labirintArray[i, j] = new LabirintBlock(true, true, true, true, false);
                }
            }
            labirintArray[0, 0].Left = false;
            labirintArray[Height-1, Width-1].Right = false;
        }

    }
}
