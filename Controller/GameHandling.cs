namespace GameOfLife
{
    public class GameHandling
    {
        private bool _gameIsRunning = true;
        private Game? _game;
        private GameGraphic? _gameGraphic;

        /// <summary>
        /// Starts and runs custom game.
        /// </summary>
        private void RunCustomGame()
        {
            int x = UserInput.GetUserInput("Enter the Heigth");
            int y = UserInput.GetUserInput("Enter the Width");

            if (UserInput.ValidateUserInputValue(x, y) == true)
            {
                _game = new Game(x, y);
                _gameGraphic = new GameGraphic(_game);

                while (Console.KeyAvailable == false)
                {
                    UpdateGameField();
                }
            }
        }
        /// <summary>
        /// Creates and displays game with default Height and Width values.
        /// </summary>
        private void RunRandomGame()
        {
            _game = new Game();
            _gameGraphic = new GameGraphic(_game);
            
            while (Console.KeyAvailable == false)
            {
                UpdateGameField();
            }
        }
        /// <summary>
        /// Displays the menu and runs the application.
        /// </summary>
        public void RunApplication()
        {
            DataManagement dataManagement = new DataManagement();

            while (_gameIsRunning)
            {
                GameMenu.DisplayApplicationMenu();
                switch (GameMenu.GetMenuResponse())
                {
                    case ConsoleKey.P:
                        RunCustomGame();
                        break;
                    case ConsoleKey.R:
                        RunRandomGame();
                        break;
                    case ConsoleKey.S:
                        dataManagement.SaveGame(_game);
                        break;
                    case ConsoleKey.L:
                        dataManagement.LoadGame();
                        break;
                    case ConsoleKey.Q:
                        _gameIsRunning = false;
                        GameMenu.DisplayExitMessage();
                        break;
                    default:
                        GameMenu.DisplayExitMessage();
                        break;
                }
            }
        }
        /// <summary>
        /// Updates game field.
        /// </summary>
        private void UpdateGameField()
        {
            while (Console.KeyAvailable == false)
            { 
                _gameGraphic.DrawGameWindow();
                _game.GenerateNextGeneration();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }
}