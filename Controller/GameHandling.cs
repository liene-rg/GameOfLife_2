namespace GameOfLife
{
    public class GameHandling
    {
        private bool gameIsRunning = true;
        Game? game;
        GameGraphic? gameGraphic;

        /// <summary>
        /// Starts and runs custom game.
        /// </summary>
        public void RunCustomGame()
        {
            int x = UserInput.GetUserInput("Enter the Heigth");
            int y = UserInput.GetUserInput("Enter the Width");

            if ((x > UserInput.maxInputValue || x < UserInput.minInputValue) || (y > UserInput.maxInputValue || y < UserInput.minInputValue))
            {
                Console.WriteLine(UserInput.wrongUserInput);
            }
            else
            {
                game = new Game(x, y);
                gameGraphic = new GameGraphic(game);

                while (Console.KeyAvailable == false)
                {
                    Console.WriteLine("Live cells: " + gameGraphic.CalculateLiveCellsCurrentGeneration() + "Iteration: " + game.iterationCount);
                    gameGraphic.DrawGameWindow();
                    game.GenerateNextGeneration();
                    Thread.Sleep(1000);
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// Creates and displays game with default Height and Width values.
        /// </summary>
        /// <returns></returns>
        public void RunRandomGame()
        {
            game = new Game();
            gameGraphic = new GameGraphic(game);
            while (Console.KeyAvailable == false)
            {
                Console.WriteLine("Live cells " + gameGraphic.CalculateLiveCellsCurrentGeneration() + "Iteration: " + game.iterationCount);
                gameGraphic.DrawGameWindow();
                game.GenerateNextGeneration();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Displays the menu and runs the application.
        /// </summary>
        public void RunApplication()
        {
            DataManagement dataManagement = new DataManagement();

            while (gameIsRunning || Console.KeyAvailable == false)
            {
                switch (GameMenu.GetMenuResponse())
                {
                    case ConsoleKey.P:
                        RunCustomGame();
                        break;
                    case ConsoleKey.R:
                        RunRandomGame();
                        break;
                    case ConsoleKey.S:
                        dataManagement.SaveGame(game);
                        break;
                    case ConsoleKey.L:
                        dataManagement.LoadGame();
                        break;
                    case ConsoleKey.Q:
                        gameIsRunning = false;
                        GameMenu.DisplayExitMessage();
                        break;
                    default:
                        GameMenu.DisplayExitMessage();
                        break;
                }
            }
        }
    }
}