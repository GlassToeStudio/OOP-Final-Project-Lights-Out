using Newtonsoft.Json;

namespace LightsOut
{
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
            using (var streamReader = new StreamReader(FileUtil.GetFile(jsonFile)))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<LevelData>(jsonString);
        }
    }
}
