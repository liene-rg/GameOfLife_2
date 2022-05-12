namespace GameOfLife
{
    public static class UserInput
    {
        private static int _validUserInput;
        private static string wrongUserInput = "Wrong input, enter different value.";
        private static int _minInputValue = 5;
        private static int _maxInputValue = 40;
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
                Console.WriteLine(wrongUserInput);
                Console.ReadLine();
            }    
            return _validUserInput;
        }
        /// <summary>
        /// Validates if user has entered the values within the required range.
        /// </summary>
        /// <param name="x ">Integer value of user input.</param>
        /// <param name="y">Integer value of user input.</param>
        /// <returns>Returns true if values are within range, false otherwise.</returns>
        public static bool ValidateUserInputValue(int x, int y )
        {
            if ((x > _maxInputValue || x < _minInputValue) || (y > _maxInputValue || y < _minInputValue))
            {
                return false;
            }
            
           else return true;
        }
    }
}