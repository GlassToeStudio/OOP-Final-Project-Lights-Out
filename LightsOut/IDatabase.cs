namespace LightsOut
{
    /// <summary>
    /// Interface for databse classes.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// List of LevelData.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <summary>
        /// Get level from database by index.
        /// </summary>
        /// <param name="index">Index of level in list. Ex: Level 1 index is 0/</param>
        /// <returns>The LevelData at the selected index.</returns>
        public LevelData this[int index]
        {
            get
            {
                return Levels[index];
            }
        }
    }
}
