using GameOfLife;
using System;

namespace GameOfLife
{
    public class GameGraphic : Game
    {
        private Game gameOfLife;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameObject"></param> Game object that will be made.
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
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Calculates and displays the number of currently live cells.
        /// </summary>
        public void CalculateLiveCellsCurrentGeneration()
        {
            int liveCells = 0;
            for (int i = 0; i < gameOfLife.Height; i++)
            {
                for (int j = 0; j < gameOfLife.Width; j++)
                {
                    if (gameOfLife.currentGeneration[i, j] == 1)
                    { 
                        liveCells++;
                    }
                }
            }
            // In some iterations returns a very big count and then returns back to correct count.
           Console.WriteLine("Live cell count " + liveCells);
        }
    }
}
