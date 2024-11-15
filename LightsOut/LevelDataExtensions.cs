using Newtonsoft.Json;

namespace LightsOut
{
    /// <summary>
    /// 
    /// </summary>
    public static class LevelDataExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="levels"></param>
        /// <returns></returns>
        public static LevelDatabase LoadLevelDatabase(this LevelDatabase levels)
        {
            return levels.LoadDatabase<LevelDatabase>("Levels.json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levels"></param>
        /// <returns></returns>
        public static UserDatabase LoadUserDatabase(this UserDatabase levels)
        {
            return levels.LoadDatabase<UserDatabase>("User.json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="levels"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private static T LoadDatabase<T>(this T levels, string databaseName)
        {
            string jsonString;
            using (var streamReader = new StreamReader(FileUtil.GetLevelDatabase(databaseName)))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
