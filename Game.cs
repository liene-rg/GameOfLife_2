using System;


namespace GameOfLife
{
    public class Game
    {

        public int Height { get; set; } // x
        public int Width { get; set; } //y

        public int[,] currentGen { get; set; }
        public int[,] nextGen { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Game(int x, int y)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.Height = x;
            this.Width = y;

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            // initiate current and next gen boards

            currentGen = new int[Height, Width];
            nextGen = new int[Height, Width];

            // loop over cells using range to set live/dead cells

            var range = new Random();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // random board

                    if (range.Next(1, 101) < 50)
                        currentGen[i, j] = 0;

                    else
                        currentGen[i, j] = 1;
                }
            }
        }

        // transfer next gen to current gen

        private void TransferNextGen()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    currentGen[i, j] = nextGen[i, j];
                }
            }
        }


        // calculate live neighbours

        private int CalcLiveNeighbours(int x, int y)
        {
            int liveNeighbours = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i < 0 || x + i >= x) // check if out of bonds
                        continue;
                    if (y + j < 0 || y + j >= y) // check if out of bonds
                        continue;
                    if (x + i == x && y + -j == y) // same cell
                        continue;

                    liveNeighbours += currentGen[x + i, y + j];
                }
            }
            return liveNeighbours;
        }

        public void GenerateNextGen()
        {
            for (int x = 0; x < this.Height; x++)
            {
                for (int y = 0; y < this.Width; y++)
                {
                    int liveNeighbours = CalcLiveNeighbours(x, y);

                    if (currentGen[x, y] == 1 && liveNeighbours > 2)
                        nextGen[x, y] = 0;

                    else if (currentGen[x, y] == 1 && liveNeighbours > 3)
                        nextGen[x, y] = 0;

                    else if (currentGen[x, y] == 0 && liveNeighbours == 3)
                        nextGen[x, y] = 1;

                    else nextGen[x, y] = currentGen[x, y];


                }
            }

            TransferNextGen();
        }

    }
}
