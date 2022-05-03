using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GameOfLife
{
    public class DataManagement
    {
       /// <summary>
       /// Saves the game to a file.
       /// </summary>
       /// <param name="game Instance of a GameGraphic class."></param>
       /// <param name="filePath File path."></param>
        public static void SaveGame(GameGraphic game, string filePath) //BinarySerialize
        {
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            fileStream = File.Create(filePath);
            binaryFormatter.Serialize(fileStream, game);
            fileStream.Close();
        }
        
        /// <summary>
        /// Loads the game from a file.
        /// </summary>
        /// <param name="filePath File path."></param>
        /// <returns></returns>
        public static object LoadGame(string filePath) // BinaryDeserialize
        {
            object? gameObj = null;
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                gameObj = binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return gameObj;
        }
    }
}
