﻿using Newtonsoft.Json;

namespace LightsOut
{
    /// <summary>
    /// Static class for Database extensions for loading database info from disk.
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Load game data from disk for this LevelDatabase Object.
        /// </summary>
        /// <param name="gameDb">this level <see cref="LevelDatabase"/></param>
        /// <returns></returns>
        public static LevelDatabase LoadLevelDatabase(this LevelDatabase gameDb)
        {
            return gameDb.LoadDatabase<LevelDatabase>("Game.json");
        }

        /// <summary>
        /// Load user data from disk for this UserDatabase Object.
        /// </summary>
        /// <param name="userDb">this <see cref="UserDatabase"/></param>
        /// <returns></returns>
        public static UserDatabase LoadUserDatabase(this UserDatabase userDb)
        {
            return userDb.LoadDatabase<UserDatabase>("User.json");
        }

        /// <summary>
        /// Load database from disk.
        /// </summary>
        /// <typeparam name="T">LevelDatabase or UserDatabase.</typeparam>
        /// <param name="db">this database</param>
        /// <param name="databaseName">database name in .json format: User.json or Game.json.</param>
        /// <returns>this Database populated with data from disk.</returns>
        private static T LoadDatabase<T>(this T db, string databaseName)
        {
            string jsonString;
            using (var streamReader = new StreamReader(FileUtil.GetDatabase(databaseName)))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
