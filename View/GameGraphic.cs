namespace GameOfLife
{
    public class GameGraphic : Game
    {
        public Game gameOfLife;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameObject Game object that will be made."></param> 
        public GameGraphic(Game gameObject)
        {
            gameOfLife = gameObject;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Draws the game board. 
        /// </summary>
        public void DrawBoard()
        {
            for (int i = 0; i < gameOfLife.Height; i++)
            {
                for (int j = 0; j < gameOfLife.Width; j++)
                {
                    if (gameOfLife.currentGeneration[i, j] == 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Displays the game and game information.
        /// </summary>
        public void DrawGameWindow()
        {
            Console.Clear();
            GameMenu.DisplayApplicationMenu();
            Console.WriteLine();
            Console.WriteLine("Live cells: " + CalculateLiveCellsCurrentGeneration() + " Iteration: " + gameOfLife.iterationCount);
            
            DrawBoard();

            if(CalculateLiveCellsCurrentGeneration() == 0)
            {
                Console.Clear();
                Console.WriteLine(GameMenu.gameFinished);
            }
        }
        /// <summary>
        /// Calculates number of live cells in current generation.
        /// </summary>
        /// <returns>Returns the number of currently alive cells.</returns>
        public int CalculateLiveCellsCurrentGeneration()
        {
            int liveCells = 0;
            for (int i = 0; i < gameOfLife.Height; i++)
            {
                for (int j = 0; j < gameOfLife.Width; j++)
                {
                    liveCells += gameOfLife.currentGeneration[i, j];
                }
            }

            return liveCells;
        }      
    }
}