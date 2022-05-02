using System;
using GameOfLife;

namespace GameOfLife
{
    public static class UserInput
    {
        public static int validUserInput;
        public static string wrongUserInput = "Wrong input, enter integer value.";
        /// <summary>
        /// Gets the value of either Height or Width from the user.
        /// </summary>
        /// <param name="promptMessage Message that will be displayed to user."></param> 
        /// <returns>Returns an integer value from user input.</returns> 
        public static int GetUserInput(string promptMessage)
        {
            Console.WriteLine(promptMessage);
            while (!Int32.TryParse(Console.ReadLine(), out validUserInput))
            {
                Console.WriteLine(wrongUserInput);
                Console.ReadLine();
            }
            return validUserInput;
        }
    }
}