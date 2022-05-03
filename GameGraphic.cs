using GameOfLife;
using System;

namespace GameOfLife
{
    [Serializable]
    public class GameGraphic : Game
    {
        private Game gameOfLife;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameObject "></param> Game object that will be made.
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
            Console.Clear();
            int liveCells = 0;
            for (int i = 0; i < gameOfLife.Height; i++)
            {
                for (int j = 0; j < gameOfLife.Width; j++)
                {
                    liveCells += gameOfLife.currentGeneration[i, j];
                }
            }

            Console.WriteLine("Live cell count " + liveCells);
        }

        //public void DisplayIterationCount()
        //{
        //    int iteration = 1;

        //    for (int i = 0; i < gameOfLife.Height; i++)
        //    {
        //        for (int j = 0; j < gameOfLife.Width; j++)
        //        {
                    
        //        }


        //    }

        //    Console.WriteLine("Iteration: " + iteration);
        //}
    }
}
