using System;
using GameOfLife;

namespace GameOfLife
{
    public static class GameHandling
    {
        /// <summary>
        /// Starts and runs the game of life.
        /// </summary>
        /// <param name="gameObject Instance of Game class."></param>
        /// <param name="gameGraphic Instance of GameGraphic class."></param>
        public static void RunGame(Game gameObject, GameGraphic gameGraphic)
        {
            while (true)
            {
                gameGraphic.DrawBoard();
                gameObject.GenerateNextGeneration();
                Thread.Sleep(1000);
                gameGraphic.CalculateLiveCellsCurrentGeneration();
            }
        }
    }
}