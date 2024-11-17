namespace LightsOut
{
    /// <summary>
    /// Container for all LevelData with helper properties for level navigation.
    /// </summary>
    public struct LevelDatabase : IDatabase
    {
        /// <summary>
        /// List of all premade LevelData. Levels are initialized with this data.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <summary>
        /// Get level from database by index.
        /// </summary>
        /// <param name="index">Index of level in list. Ex: Level 1 index is 0/</param>
        /// <returns>The LevelData at the selected index.</returns>
        public readonly LevelData this[int index] => Levels[index];

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LevelDatabase()
        {
            Levels = [];
        }
    }
}
