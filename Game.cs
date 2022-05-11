using System;

namespace GameOfLife
{
    [Serializable]
    public class Game
    {
        /// <summary>
        /// Properties.
        /// </summary>
        public int Height { get; set; }
        public int Width { get; set; }
        public int[,] currentGeneration { get; private set; }
        public int iterationCount = 1;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public Game()
        {
            Height = 16;
            Width = 16;
            currentGeneration = new int[Height, Width];

            InitializeBoard();
        }

        /// <summary>
        /// Constructor with parameters from user.
        /// </summary>
        /// <param name="x Number of rows (height)."></param> 
        /// <param name="y  Number of columns (width)."></param>
        public Game(int x, int y)
        {
            this.Height = x;
            this.Width = y;

            currentGeneration = new int[Height, Width];

            InitializeBoard();
        }
        /// <summary>
        /// Initiate current and next generation boards.
        /// </summary>
        private void InitializeBoard()
        {
            //Loop over cells using range to set live/ dead cells.

            var range = new Random();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // Create a random board.

                    if (range.Next(1, 101) < 70)
                    {
                        currentGeneration[i, j] = 0;
                    }
                    else
                    {
                        currentGeneration[i, j] = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Calculate live neighbours.
        /// </summary>
        /// <param name="currentRow Height"></param>
        /// <param name="currentColumn Width."></param>
        /// <returns>Returns number of neighbours.</returns>
        public int CalcLiveNeighbours(int currentRow, int currentColumn)
        {
            int liveNeighbours = 0;
            for (int rowOffSet = -1; rowOffSet <= 1; rowOffSet++)
            {
                for (int columnOffSet = -1; columnOffSet <= 1; columnOffSet++)
                {
                    int actualRow = (currentRow + rowOffSet + Height) % Height;
                    int actualColumn = (currentColumn + columnOffSet + Width) % Width;
                    liveNeighbours += currentGeneration[actualRow, actualColumn];
                }
            }

            return liveNeighbours - currentGeneration[currentRow, currentColumn];
        }

        /// <summary>
        /// Create the next generation.
        /// </summary>
        public void GenerateNextGeneration()
        {
            int[,] nextGeneration = new int[Height, Width];
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

            currentGeneration = nextGeneration;
            iterationCount++;
        }
    }
}