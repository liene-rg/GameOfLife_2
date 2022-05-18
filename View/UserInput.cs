namespace GameOfLife
{
    public static class UserInput
    {
        private static int _validUserInput;
        private static string _wrongUserInput = "Wrong input, enter different value.";

        /// <summary>
        /// Gets the value of either Height or Width from the user.
        /// </summary>
        /// <param name="promptMessage">Message that will be displayed to user.</param> 
        /// <returns>Returns an integer value from user input.</returns> 
        public static int GetUserInput(string promptMessage)
        {
            Console.WriteLine(promptMessage);
            while (!Int32.TryParse(Console.ReadLine(), out _validUserInput))
            {
                Console.WriteLine(_wrongUserInput);
                Console.ReadLine();
            }

            return _validUserInput;
        }

        /// <summary>
        /// Validates if user has entered the values within the required range.
        /// </summary>
        /// <param name="row">Integer value of user input.</param>
        /// <param name="column">Integer value of user input.</param>
        /// <returns>Returns true if values are within range, false otherwise.</returns>
        public static bool ValidateUserInputValue(int row, int column)
        {
            if ((row >= GameParameters.MinInputValue && row <= GameParameters.MaxInputValue) && 
                (column >= GameParameters.MinInputValue && column <= GameParameters.MaxInputValue))
            {
                return true;
            }
            
           return false;
        }
    }
}