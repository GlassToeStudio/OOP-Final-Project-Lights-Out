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
        /// <param name="levelData"></param>
        /// <param name="jsonFile"></param>
        /// <returns></returns>
        public static LevelData LoadLevelDataFromJson(this LevelData levelData, string jsonFile)
        {
            string jsonString;
            using (var streamReader = new StreamReader(FileUtil.GetLevelFile(jsonFile)))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<LevelData>(jsonString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levels"></param>
        /// <returns></returns>
        public static LevelDatabase LoadLevels(this LevelDatabase levels)
        {
            string jsonString;
            using (var streamReader = new StreamReader(FileUtil.GetLevelFile("Levels.json")))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<LevelDatabase>(jsonString);
        }

        public static T LoadData<T>(this T levels)
        {
            string jsonString;
            using (var streamReader = new StreamReader(FileUtil.GetLevelFile("Levels.json")))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
