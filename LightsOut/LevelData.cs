using Newtonsoft.Json;

namespace LightsOut
{
    public struct LevelData
    {
        public int Level;
        public int Size;
        public int MinMoves;
        public int[] Board = [];

        public LevelData() { }
        public LevelData(int level, int size, int minMoves)
        {
            Level = level;
            Size = size;
            MinMoves = minMoves;
            Board = new int[Size * Size];
        }

        public LevelData(LevelData levelData)
        {
            Level = levelData.Level;
            Size = levelData.Size;
            MinMoves = levelData.MinMoves;
            Board = new int[Size * Size];

            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = levelData.Board[i];
            }
        }
    }

    public static class LeveLdataExtensions
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
            using (var streamReader = new StreamReader(FileUtil.GetFileLocation(jsonFile)))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<LevelData>(jsonString);
        }
    }
}
