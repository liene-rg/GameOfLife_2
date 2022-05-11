using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameMenu
    {
        public static string newCustomGameOption = "Press 'P' to Play game";
        public static string newRandomGameOptions = "Press 'R' to Play Random game";
        public static string saveGameOption = "Press 'S' to Save game";
        public static string loadGameOption = "Press 'L' to Load game";
        public static string quitGameOption = "Press 'Q' to Quit game";
        public static string gameFinished = "Game finished.";
        public static string gameTitle = "Game Of Life";
        /// <summary>
        /// Get response from user.
        /// </summary>
        /// <returns>Returns menu input from user.</returns>
        public static ConsoleKey GetMenuResponse()
        {
            DisplayApplicationMenu();
            return Console.ReadKey(true).Key;    
        }
        /// <summary>
        /// Displays the menu on console.
        /// </summary>
        public static void DisplayApplicationMenu()
        {
            Console.Title = gameTitle;
            Console.WriteLine(newCustomGameOption);
            Console.WriteLine(newRandomGameOptions);
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
