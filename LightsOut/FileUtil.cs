using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        /// <summary>
        /// Path to resources.
        /// </summary>
        internal static readonly string RESOURCES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\");
        /// <summary>
        /// Path to game and user data
        /// </summary>
        internal static readonly string LEVELS = Path.Combine(RESOURCES, "Levels\\");
        /// <summary>
        /// Path to sound clips
        /// </summary>
        internal static readonly string SOUNDS = Path.Combine(RESOURCES, "Sounds\\");
        /// <summary>
        /// This project directory on disk - specific for updating game data and user data for the repo.
        /// </summary>
        internal static readonly string PROJECT_DIR = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,"Resources\\Levels\\");

        internal static string GetLevelDatabase(string fileName)
        {
            return Path.Combine(LEVELS, fileName);
        }

        internal static string GetSoundFile(string fileName)
        {
            return Path.Combine(SOUNDS, fileName);
        }

        private static void SaveDatabase(IDatabase dataBase, string dbName)
        {
            var data = JsonConvert.SerializeObject(dataBase);
            // Write to internal directory
            File.WriteAllText(GetLevelDatabase($"{dbName}.json"), data);
            // Write to project directory to keep project and repo up to date with changes.
            File.WriteAllText($"{PROJECT_DIR}{dbName}.json", data);
        }

        internal static void SaveUserData(UserDatabase userDataBase)
        {
            SaveDatabase(userDataBase, "User");
        }  
        internal static void SaveGameData(LevelDatabase levelDatabase)
        {
            SaveDatabase(levelDatabase, "Game");
        }
    }
}
