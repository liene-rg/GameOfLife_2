using GameOfLife;
using System;

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
                Console.WriteLine("Game ended");
            }
        }

        /// <summary>
        /// Calculates and returns the number of currently live cells.
        /// </summary>
        public int CalculateLiveCellsCurrentGeneration()
        {
            //Console.Clear();
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