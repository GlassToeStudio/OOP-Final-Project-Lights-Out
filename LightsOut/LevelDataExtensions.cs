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
    }
}
