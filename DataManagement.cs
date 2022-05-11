using System;
using System.IO;
using System.Collections.Generic;
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
        /// <param name="game Instance of a GameGraphic class."></param>

        //public static void SaveGame(Game game) //BinarySerialize
        //{
        //    FileStream fileStream;
        //    BinaryFormatter binaryFormatter = new BinaryFormatter();
        //    if (File.Exists(filePath))
        //    {
        //        File.Delete(filePath);
        //    }

        //    fileStream = File.Create(filePath);
        //    binaryFormatter.Serialize(fileStream, game);
        //    fileStream.Close();
        //}

        ///// <summary>
        ///// Loads the game from a file.
        ///// </summary>
        ///// <param name="filePath File path."></param>
        ///// <returns></returns>
        //public static object LoadGame() // BinaryDeserialize
        //{
        //    object gameObj = new Game();
        //    FileStream fileStream;
        //    BinaryFormatter binaryFormatter = new BinaryFormatter();
        //    if (File.Exists(filePath))
        //    {
        //        fileStream = File.OpenRead(filePath);
        //        gameObj = binaryFormatter.Deserialize(fileStream);
        //        fileStream.Close();
        //    }
        //    return gameObj;
        //}

        public void SaveGame(Game game)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Serialize(fileStream, game);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("failed to save the game" + exception.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public Game LoadGame()
        {
            Game gameData = new Game();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                gameData = (Game)binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Failed to load the game " + exception.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
            return gameData;
        }

    }
}