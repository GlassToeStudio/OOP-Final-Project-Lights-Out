namespace LightsOut
{
    /// <summary>
    /// Container for all LevelData with helper properties for level navigation.
    /// </summary>
    public struct LevelDatabase : IDatabase
    {
        /// <summary>
        /// Array of all premade LevelData. Levels are initialized with this data.
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

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LevelDatabase()
        {
            Levels = [];
        }
    }
}
