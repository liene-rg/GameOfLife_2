using GameOfLife;

namespace GameOfLife
{
    public class Program : UserInput
    {
        public static void Main(string[] args)
        {
            int x = UserInputHeight();
            int y = UserInputHeight();

            Console.Clear();

            Game game = new Game(x, y);

            GameGraphic gameGraphic = new GameGraphic(game);

            while (true)
            {
                gameGraphic.DrawBoard();
                game.GenerateNextGeneration();

                // Updates every second.
                Thread.Sleep(1000);
            }
        }
    }
}
