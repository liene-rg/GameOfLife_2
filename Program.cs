using GameOfLife;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            int x = UserInput.GetUserInput("Enter the Heigth");
            var y = UserInput.GetUserInput("Enter the Width");

            Console.Clear();

            Game game = new Game(x,y);

            GameGraphic gameGraphic = new GameGraphic(game);

            GameHandling.RunGame(game, gameGraphic);
        }
    }
}
