using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;

namespace GameOfLife
{
    public static class UserInput
    {
        /// <summary>
        /// Returns an int of Height from user input.
        /// </summary>
        /// <returns></returns>
        /// 
        public static int validUserInput;
        public static string wrongUserInput = "Wrong input, enter integer value.";

        /// <summary>
        /// Gets the value of either Height or Width from the user.
        /// </summary>
        /// <param name="promptMessage"></param> Message that will be displayed to user.
        /// <returns></returns> Returns an integer value from user input.
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