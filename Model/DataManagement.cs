using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GameOfLife
{
    public class DataManagement
    {
        private string filePath = "gameOutput.txt";
        private Game game;
        /// <summary>
        /// Saves the game to a file.
        /// </summary>
        /// <param name="game Instance of a Game class."></param>
        public void SaveGame(Game game)
        {
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            fileStream = File.Create(filePath);
            try
            {
                binaryFormatter.Serialize(fileStream, game);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine(GameMenu.failedToSaveMsg + exception.Message);
                throw;
            }
            Console.WriteLine(GameMenu.gameSaved);
            fileStream.Close();
        }
        /// <summary>
        /// Retrieves the game information and loads the game from a file.
        /// </summary>
        /// <returns>Returns the object previosly saved on the file.</returns>
        public Game LoadGame()
        {
            game = new Game();
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                try
                {
                    fileStream = File.OpenRead(filePath);
                    game = (Game)binaryFormatter.Deserialize(fileStream);
                }
                catch (SerializationException exception)
                {
                    Console.WriteLine(GameMenu.failedToLoadMsg + exception.Message);
                    throw;
                }
                fileStream.Close();
            }
            return game;
        }
    }
}