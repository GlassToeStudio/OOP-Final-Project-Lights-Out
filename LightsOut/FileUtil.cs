using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        /// <summary>
        /// Path to resources folder.
        /// </summary>
        internal static readonly string RESOURCES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\");
        /// <summary>
        /// Path to game and user data. In resources folder.
        /// </summary>
        internal static readonly string DATA = Path.Combine(RESOURCES, "Data\\");
        /// <summary>
        /// Path to sound clips. In resources folder.
        /// </summary>
        internal static readonly string SOUNDS = Path.Combine(RESOURCES, "Sounds\\");
#if DEBUG
        /// <summary>
        /// This project directory on disk - specific for updating game data and user data for the repo.
        /// </summary>
        internal static readonly string PROJECT_DIR = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,"Resources\\Data\\");
#endif
        /// <summary>
        /// Get the file path to ../Resources/Data/Database by file name. Either GameDatabase (Game) or UserDatabase (User).
        /// </summary>
        /// <param name="databaseFileName">The name of the database file: "Game", "User".</param>
        /// <returns>Path to Game or User database which can be streamed and deserialized.</returns>
        internal static string GetDatabase(string databaseFileName)
        {
            return Path.Combine(DATA, databaseFileName);
        }
        /// <summary>
        /// Get the file path to ../Resources/Sounds/Soundfile by file name. (LightClick.wav)
        /// </summary>
        /// <param name="soundFileName">The name of the sound file</param>
        /// <returns>Path to sound file to be played via SoundPlayer</returns>
        internal static string GetSoundFile(string soundFileName)
        {
            return Path.Combine(SOUNDS, soundFileName);
        }
        /// <summary>
        /// Save the given IDatabase object to disk. Saves to internal program resources directory.Saves to working project directory for development if DEBUG.
        /// <para>File extension ".json" is appended to file name so pass file anme without extension.</para>
        /// </summary>
        /// <param name="database">The database to serialize to disk. GameDatabase or UserDatabase.</param>
        /// <param name="databaseName">The name of the file that is written to disk, "Game" or"User"</param>
        private static void SaveDatabase(IDatabase database, string databaseName)
        {
            var data = JsonConvert.SerializeObject(database);
            // Write to internal directory
            File.WriteAllText(GetDatabase($"{databaseName}.json"), data);
#if DEBUG
            // Write to project directory to keep project and repo up to date with changes.
            File.WriteAllText($"{PROJECT_DIR}{databaseName}.json", data);
#endif
        }
        /// <summary>
        /// Save UserDatabase to disk.
        /// </summary>
        /// <param name="userDataBase">UserDatabase object to save to disk.</param>
        internal static void SaveUserData(UserDatabase userDataBase)
        {
            SaveDatabase(userDataBase, "User");
        }
#if DEBUG
        /// <summary>
        /// Save GameDatabase to disk. Used to update LevelDatabase when we generate a random level and wish to add it to the database. Not for use in production.
        /// </summary>
        /// <param name="levelDatabase">GameDatabase object to save to disk.</param>
        internal static void SaveGameData(LevelDatabase levelDatabase)
        {
            SaveDatabase(levelDatabase, "Game");
        }
#endif
    }
}
