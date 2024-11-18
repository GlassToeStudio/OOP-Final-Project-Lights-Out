namespace LightsOut
{
    /// <summary>
    /// Database for holding user save data for each level and general game play.
    /// </summary>
    public struct UserDatabase : IDatabase
    {
        /// <summary>
        /// List of LevelData. Holds users save data for each level.
        /// </summary>
        public List<LevelData> Levels { get; set; }
        /// <summary>
        /// The index of the current level in the database.
        /// </summary>
        public int SelectedIndex { get; set; } = 0;
        /// <summary>
        /// The maximum index selectable in the database. Indicates highest unlocked level.
        /// </summary>
        public int MaxIndex { get; set; } = 0;
        /// <summary>
        /// The current selected level.
        /// </summary>
        public LevelData CurrentLevel => Levels[SelectedIndex];
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
            set { 
                Levels[SelectedIndex] = value;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UserDatabase()
        {
            Levels = [];
        }

        /// <summary>
        /// Add a level to the database.
        /// </summary>
        /// <param name="levelData"></param>
        public void AddLevel(LevelData levelData)
        {
            Levels.Add(levelData);
        }
    }
}
