using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;

namespace GameOfLife
{
    public class DataManagement
    {
        private string filePath = "gameOutput.txt";
        /// <summary>
        /// Saves the game to a file.
        /// </summary>
        /// <param name="game Instance of a Game class."></param>
        public void SaveGame(Game game)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(fileStream, game);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine(GameMenu.failedToSaveMsg + exception.Message);
                throw;
            }

            fileStream.Close();
        }
        /// <summary>
        /// Retrieves the game information and loads the game from a file.
        /// </summary>
        /// <returns>Returns the object previosly saved on the file.</returns>
        public Game LoadGame()
        {
            Game game = new Game();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                game = (Game)binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine(GameMenu.failedToLoadMsg + exception.Message);
                throw;
            }

            fileStream.Close();

            return game;
        }
    }
}