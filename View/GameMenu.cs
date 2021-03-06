namespace GameOfLife
{
    public class GameMenu
    {
        public static string newCustomGameOption = "Press 'P' to Play Custom game.";
        public static string newRandomGameOptions = "Press 'R' to Play Random game.";
        public static string saveGameOption = "Press 'S' to Save game.";
        public static string loadGameOption = "Press 'L' to Load game.";
        public static string quitGameOption = "Press 'Q' to Quit game.";
        public static string gameFinished = "Game finished.";
        public static string gameTitle = "Game Of Life";
        public static string failedToSaveMsg = "Failed to Save game.";
        public static string failedToLoadMsg = "Failed to Load game.";
        public static string gameSaved = "Game saved.";

        /// <summary>
        /// Get response from user.
        /// </summary>
        /// <returns>Returns menu input from user.</returns>
        public static ConsoleKey GetMenuResponse()
        {
            return Console.ReadKey(true).Key;    
        }

        /// <summary>
        /// Displays the menu on console.
        /// </summary>
        public static void DisplayApplicationMenu()
        {
            Console.Clear();
            Console.Title = gameTitle;
            Console.WriteLine(newCustomGameOption);
            Console.WriteLine(newRandomGameOptions);
            Console.WriteLine(quitGameOption);
        }

        /// <summary>
        /// Displays the menu while game is running on console.
        /// </summary>
        public static void DisplayGameMenu()
        {
            Console.Clear();
            Console.Title = gameTitle;
            Console.WriteLine(saveGameOption);
            Console.WriteLine(loadGameOption);
            Console.WriteLine(quitGameOption);
        }

        /// <summary>
        /// Displays the exit message after user has exited the game.
        /// </summary>
        public static void DisplayExitMessage()
        {
            Console.Clear();
            Console.WriteLine(gameFinished);
        }
    }
}
