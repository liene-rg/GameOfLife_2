using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;

namespace GameOfLife
{
    public class UserInput
    {
        /// <summary>
        /// Returns an int of Height from user input.
        /// </summary>
        /// <returns></returns>
        public static int UserInputHeight()
        {
            int x;
            Console.WriteLine("Enter the height of the board.");
            var temp = Console.ReadLine();

            while (!Int32.TryParse(temp, out x))
            {
                Console.WriteLine("Wrong input, enter integer value of heigth.");
                temp = Console.ReadLine();
            }

            return x;
        }

        /// <summary>
        /// Returns an int of Width from user input.
        /// </summary>
        /// <returns></returns>
        public static int UserInputWidth()
        {
            int y;
            Console.WriteLine("Enter the height of the board.");
            var temp = Console.ReadLine();

            while (!Int32.TryParse(temp, out y))
            {
                Console.WriteLine("Wrong input, enter integer value of heigth.");
                temp = Console.ReadLine();
            }

            return y;
        }
    }
}
