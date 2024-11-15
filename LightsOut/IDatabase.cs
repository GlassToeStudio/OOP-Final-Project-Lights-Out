namespace LightsOut
{
    /// <summary>
    /// Interface for databse classes.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Array of LevelData.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <summary>
        /// Get level from database by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LevelData this[int index]
        {
            get
            {
                return Levels[index];
            }
        }
    }
}
