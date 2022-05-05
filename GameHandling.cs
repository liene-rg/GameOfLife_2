using System;
using GameOfLife;
using System.Diagnostics;

namespace GameOfLife
{
    public class GameHandling
    {
        public static string filePath = "gameOutput.txt";

        /// <summary>
        /// Runs the game without user input.
        /// </summary>
        public static void RunDefaultGame()
        {
            Game game = new Game();
            GameGraphic gameGraphicsManager = new GameGraphic(game);
            while (true)
            {
                gameGraphicsManager.CalculateLiveCellsCurrentGeneration();
                gameGraphicsManager.DrawBoard();
                game.GenerateNextGeneration();
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Runs the game with user input.
        /// </summary>
        public static void RunCustomGame()
        {
            int x = UserInput.GetUserInput("Enter the Heigth");
            var y = UserInput.GetUserInput("Enter the Width");

            Game game = new Game(x, y);
            GameGraphic gameGraphicsManager = new GameGraphic(game);
            while (true)
            {
                gameGraphicsManager.CalculateLiveCellsCurrentGeneration();
                gameGraphicsManager.DrawBoard();
                game.GenerateNextGeneration();
                Thread.Sleep(1000);
            }
        }
        public static void StartApplication()
        {
            while (true)
            {
                //Console.Clear();
                GameMenu.PrintMenu();

                switch (GameMenu.GetMenuResponse())
                {
                    case "N":
                        {
                            GameHandling.RunCustomGame();
                        }
                        break;
                    case "R":
                        {
                            GameHandling.RunDefaultGame();
                        }
                        break;
                    case "L":
                        {
                            DataManagement dataManagement = new DataManagement();
                            dataManagement.LoadGame(filePath);
                        }
                        break;
                    case "S":
                        {
                            //DataManagement.SaveGame();
                        }
                        break;
                    case "Q":
                        {

                        }
                        break;
                }
            }
        }
    }
}