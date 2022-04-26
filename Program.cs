using GameOfLife;

namespace GameOfLife
{

    public class Program
    {

        public static void Main(string[] args)
        {
            int x, y;

            Console.WriteLine("Enter the height of the board. Value should be over 40"); // will implement x<40 check later
            var temp = Console.ReadLine();
            while (!Int32.TryParse(temp, out x))
            {
                Console.WriteLine("Wrong input, enter integer value of heigth.");
                temp = Console.ReadLine();
            }

            Console.WriteLine("Enter the width of the game board.Value should be over 90");

            while (!Int32.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Wrong input, enter integer value of width.");
                temp = Console.ReadLine();
            }


            Console.Clear();

            Game gameOfLife = new Game(x, y);


            Game_Graphic gameView = new Game_Graphic(gameOfLife);

            while (true)
            {
                gameView.DrawBoard();
                gameOfLife.GenerateNextGen();

                Thread.Sleep(1000); // updates every second
            }

        }

    }
}
