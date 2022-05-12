using GameOfLife;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int x = UserInput.GetUserInput("Enter the Heigth");
            var y = UserInput.GetUserInput("Enter the Width");
            Game game = new Game(x, y);
            GameGraphic gameGraphic = new GameGraphic(game);

            string filePath = "gameOutput.txt";
            DataManagement dataManagement = new DataManagement();
            GameGraphic? gameGraphic1 = null;
            DataManagement.SaveGame(gameGraphic, filePath);
            gameGraphic1 = DataManagement.LoadGame(filePath) as GameGraphic;

         
            //while (isGameOngoing)
            //{
            //    int response = GetMenuResponse();
            //    switch (response)
            //    {
            //        case 0:
            //            RunGame();
            //            break;
            //        case 1:
            //            LoadSavedGame();
            //            break;
            //        case 2:
            //            isGameOnGoing = false;
            //            break;
            //    }
            //}
            GameHandling.RunGame(game, gameGraphic);
        }
    }
}