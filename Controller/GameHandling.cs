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
                    UpdateGameField(_game, _gameGraphic);
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
                UpdateGameField(_game, _gameGraphic);
            }
        }
        /// <summary>
        /// Runs and displays previosly saved game.
        /// </summary>
        /// <param name="dataManagement object"></param>
        private void RunSavedGame(DataManagement dataManagement)
        {
            Game _savedGame = dataManagement.LoadGame();
            GameGraphic _savedGraphic= new GameGraphic(_savedGame);

            while (Console.KeyAvailable == false)
            {
                UpdateGameField(_savedGame, _savedGraphic);
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
                        RunSavedGame(dataManagement);
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
       /// Updates and displays the game.
       /// </summary>
       /// <param name="game Instance of Game class."></param>
       /// <param name="gameGraphic Instance of GameGraphic class."></param>
        private void UpdateGameField(Game game, GameGraphic gameGraphic)
        {
            while (Console.KeyAvailable == false)
            { 
                gameGraphic.DrawGameWindow();
                game.GenerateNextGeneration();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }
}