namespace GameOfLife
{
    public class GameHandling
    {
        private bool _isApplicationRunning = true;
        private bool _isGameRunning = true;
        private Game? _game;
        private GameGraphic? _gameGraphic;
        private DataManagement dataManagement;

        /// <summary>
        /// Displays the menu and runs the application.
        /// </summary>
        public void RunApplication()
        {
            dataManagement = new DataManagement();

            while (_isApplicationRunning)
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
                    case ConsoleKey.Q:
                        _isApplicationRunning = false;
                        GameMenu.DisplayExitMessage();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Starts and runs custom game.
        /// </summary>
        private void RunCustomGame()
        {
            int row = UserInput.GetUserInput("Enter the Heigth");
            int column = UserInput.GetUserInput("Enter the Width");

            if (UserInput.ValidateUserInputValue(row, column) == true)
            {
                _game = new Game(row, column);
                _gameGraphic = new GameGraphic(_game);
                RunGame();
            }
        }

        /// <summary>
        /// Creates and displays game with default Height and Width values.
        /// </summary>
        private void RunRandomGame()
        {
            _game = new Game();
            _gameGraphic = new GameGraphic(_game);
            RunGame();
        }

        /// <summary>
        /// Runs the game and displays game menu.
        /// </summary>
        private void RunGame()
        {
            _isGameRunning = true;
            while (_isGameRunning)
            {
                UpdateGameField(_game, _gameGraphic);
                if (Console.KeyAvailable)
                {
                    var consoleKey = Console.ReadKey(true);
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.S:
                            dataManagement.SaveGame(_game);
                            break;
                        case ConsoleKey.L:
                            dataManagement.LoadGame();
                            RunSavedGame(dataManagement);
                            break;
                        case ConsoleKey.Q:
                            _isGameRunning = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Runs and displays previosly saved game.
        /// </summary>
        /// <param name="dataManagement">Instance of DataManagement class.</param>
        private void RunSavedGame(DataManagement dataManagement)
        {
            Game _savedGame = dataManagement.LoadGame();
            GameGraphic _savedGraphic = new GameGraphic(_savedGame);
            while (Console.KeyAvailable == false)
            {
                UpdateGameField(_savedGame, _savedGraphic);
            }
        }

        /// <summary>
        /// Updates and displays the game.
        /// </summary>
        /// <param name="game">Instance of Game class.</param>
        /// <param name="gameGraphic">Instance of GameGraphic class.</param>
        private void UpdateGameField(Game game, GameGraphic gameGraphic)
        {
                gameGraphic.DrawGameWindow();
                game.GenerateNextGeneration();
                Thread.Sleep(1000);
                Console.WriteLine();
        }
    }
}