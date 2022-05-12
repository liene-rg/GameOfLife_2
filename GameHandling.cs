using System;
using GameOfLife;
using System.Diagnostics;

namespace GameOfLife
{
    public static class GameHandling
    {
        public static bool isGameOngoing = false;
        /// <summary>
        /// Starts and runs the game of life.
        /// </summary>
        /// <param name="gameObject Instance of Game class."></param>
        /// <param name="gameGraphic Instance of GameGraphic class."></param>
        public static void RunGame(Game gameObject, GameGraphic gameGraphic)
        {
            while (true)
            {
                gameGraphic.CalculateLiveCellsCurrentGeneration();
                //gameGraphic.DisplayIterationCount();
                gameGraphic.DrawBoard();
                gameObject.GenerateNextGeneration();
                //var key = Console.ReadKey().ToString(); //need to get console pressed key
                //switch (key)
                //{
                //    case "s":
                //        DataManagement.SaveGame();
                //        break;
                //    case "l":
                //        DataManagement.LoadGame();
                //        break;
                //    case "q":
                       
                //        break;
                //        //Game is running false . game quit
                //}
                Thread.Sleep(1000);
            }          
        }

        public static void GetMenuResponse()
        {

        }
    }
}