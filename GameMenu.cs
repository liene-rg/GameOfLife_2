using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameMenu
    {
        public static string saveGameOption = "Enter 'S' to save the game";
        public static string loadGameOption = "Enter 'L' to load the game";
        public static  string quitGameOption = "Enter 'Q' to quit the game";
        public static string customGameOption = "Enter 'N' to play new custom size game";
        public static string randomGameOption = "Enter 'R' to play new random game";

        /// <summary>
        /// Prints the menu on the screen.
        /// </summary>
        public static void PrintMenu()
        {
            Console.WriteLine(customGameOption);
            Console.WriteLine(randomGameOption);
            Console.WriteLine(saveGameOption);
            Console.WriteLine(loadGameOption);
            Console.WriteLine(quitGameOption);
        }

        /// <summary>
        /// Get response from user.
        /// </summary>
        /// <returns>Returns menu input from user.</returns>
        public static string GetMenuResponse()
        {
            string userInputFromMenuOptions = Console.ReadLine();
            return userInputFromMenuOptions.ToUpper();
        }
    }
}
