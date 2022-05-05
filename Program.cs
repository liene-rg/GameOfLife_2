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
            //GameMenu.PrintMenu();
            GameHandling.StartApplication();


            //string filePath = "gameOutput.txt";
            //DataManagement dataManagement = new DataManagement();
            //GameGraphic? gameGraphic1 = null;
            //bool showMenu = true;
            //while (showMenu)
            //{
            //    GameMenu menu = new GameMenu();
            //    string response = menu.GetMenuResponse();
            //    switch (response)
            //    {
            //        case "N":
            //            int x = UserInput.GetUserInput("Enter the Heigth");
            //            var y = UserInput.GetUserInput("Enter the Width");
            //            Game game = new Game(x, y);
            //            GameGraphic gameGraphic = new GameGraphic(game);
            //            GameHandling.RunGame(game, gameGraphic);
            //            break;
            //        case "S":
            //            dataManagement.SaveGame(gameGraphic, filePath);
            //            break;
            //        case "L":
            //            dataManagement.LoadGame(filePath);
            //            break;
            //        case "Q":
            //            showMenu = false;
            //            break;
            //    }
            //}

        }
    }
}