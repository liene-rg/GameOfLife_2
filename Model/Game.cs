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
            Height = GameParameters.rows;
            Width = GameParameters.columns;
            currentGeneration = new int[Height, Width];

            InitializeBoard();
        }

        /// <summary>
        /// Constructor with parameters from user.
        /// </summary>
        /// <param name="row Number of rows (height)."></param> 
        /// <param name="column  Number of columns (width)."></param>
        public Game(int row, int column)
        {
            this.Height = row;
            this.Width = column;

            currentGeneration = new int[Height, Width];
            InitializeBoard();
        }

        /// <summary>
        /// Initiate current and next generation boards.
        /// </summary>
        private void InitializeBoard()
        {
            var range = new Random();
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    if (range.Next(1, 101) < 70)
                    {
                        currentGeneration[row, column] = 0;
                    }
                    else
                    {
                        currentGeneration[row, column] = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Calculate live neighbours.
        /// </summary>
        /// <param name="currentRow Height"></param>
        /// <param name="currentColumn Width."></param>
        /// <returns>Returns number of live neighbours.</returns>
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
            for (int row = 0; row < this.Height; row++)
            {
                for (int column = 0; column < this.Width; column++)
                {
                    int liveNeighbours = CalcLiveNeighbours(row, column);

                    switch (liveNeighbours)
                    {
                        case 3:
                            nextGeneration[row, column] = 1;
                            break;
                        case 2:
                            nextGeneration[row, column] = currentGeneration[row, column];
                            break;
                        default:
                            nextGeneration[row, column] = 0;
                            break;
                    }
                }
            }

            currentGeneration = nextGeneration;
            iterationCount++;
        }
    }
}