using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        internal static readonly string RESOURCES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\");
        internal static readonly string LEVELS = Path.Combine(RESOURCES, "Levels\\");
        internal static readonly string SOUNDS = Path.Combine(RESOURCES, "Sounds\\");
        internal static readonly string PROJECT_DIR = "C:\\Users\\GlassToe\\Documents\\Calhoun Comminity College\\Fall 24\\CIS 285 - Object-Oriented Programming (11022)\\Final Project\\OOP-Final-Project-Lights-Out\\LightsOut\\Resources\\Levels\\";

        internal static string GetLevelDatabase(string fileName)
        {
            return Path.Combine(LEVELS, fileName);
        }
        internal static string GetUserDatabase(string fileName)
        {
            return GetLevelDatabase(fileName);
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
            // Write to project dirctory to keep project and repo up to date with changes.
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
