using System;

namespace GameOfLife
{
    public class Game
    {
        /// <summary>
        /// Properties.
        /// </summary>
        public int Height { get; } 
        public int Width { get; } 
        public int[,] currentGeneration { get; private set; }

        private int[,] nextGeneration;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public Game()
        {
            Height = 16;
            Width = 16;

            currentGeneration = new int[Height, Width];
            nextGeneration = new int[Height, Width];

            InitializeBoard();
        }

        /// <summary>
        /// Constructor with parameters from user.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Game(int x, int y)
        {
            this.Height = x;
            this.Width = y;

            currentGeneration = new int[Height, Width];
            nextGeneration = new int[Height, Width];

            InitializeBoard();
        }
        /// <summary>
        /// Initiate current and next generation boards.
        /// </summary>
        private void InitializeBoard()
        {
            // Loop over cells using range to set live/dead cells.

            var range = new Random();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // Create a random board.

                    if (range.Next(1, 101) < 50)
                        currentGeneration[i, j] = 0;

                    else
                        currentGeneration[i, j] = 1;
                }
            }
        }

        /// <summary>
        /// Transfer next generation to current generation.
        /// </summary>
        private void TransferNextGeneration()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    currentGeneration[i, j] = nextGeneration[i, j];
                }
            }

        }

        /// <summary>
        /// Calculate live neighbours.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CalcLiveNeighbours(int x, int y)
        {
            int liveNeighbours = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Checks if out of bonds.

                    if (x + i < 0 || x + i >= Height)
                        continue;
                    if (y + j < 0 || y + j >= Width)
                        continue;

                    //Check if the same cell.

                    if (x + i == x && y + j == y)
                        continue;

                    liveNeighbours += currentGeneration[x + i, y + j];
                }
            }
            return liveNeighbours;
        }

        /// <summary>
        /// Create the next generation.
        /// </summary>
        public void GenerateNextGeneration()
        {
            for (int x = 0; x < this.Height; x++)
            {
                for (int y = 0; y < this.Width; y++)
                {
                    int liveNeighbours = CalcLiveNeighbours(x, y);

                    switch (liveNeighbours)
                    {
                        case 3:
                            nextGeneration[x, y] = 1;
                            break;
                        case 2:
                            nextGeneration[x, y] = currentGeneration[x, y];
                            break;
                        default:
                            nextGeneration[x, y] = 0;
                            break;
                    }
                }
            }

            TransferNextGeneration();
        }
    }
}
