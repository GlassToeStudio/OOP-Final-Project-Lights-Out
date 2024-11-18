using Newtonsoft.Json.Linq;

namespace LightsOut
{
    /// <summary>
    /// Database for holding user save data for each level and general game play.
    /// </summary>
    public struct UserDatabase : IDatabase
    {
        /// <summary>
        /// List of <see cref="LevelData"/>. Holds users save data for each level.
        /// </summary>
        public List<LevelData> Levels { get; set; }
        /// <summary>
        /// The index of the current selected level in the  <see cref="IDatabase"/>.
        /// </summary>
        public int SelectedIndex { get; set; } = 0;
        /// <summary>
        /// The maximum index selectable in the  <see cref="IDatabase"/>. Indicates highest unlocked level.
        /// </summary>
        public int MaxIndex { get; set; } = 0;
        /// <summary>
        /// The current selected level.
        /// </summary>
        public LevelData CurrentLevel => Levels[SelectedIndex];
        /// <inheritdoc/>
        public readonly LevelData this[int index] => Levels[index];

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UserDatabase()
        {
            Levels = [];
        }

        /// <summary>
        /// Add a level to the database. When a level is first cleared, the level at the next index is added to this Levels list.
        /// </summary>
        /// <param name="levelData"></param>
        public readonly void AddLevel(LevelData levelData)
        {
            Levels.Add(levelData);
        }

        /// <summary>
        /// Update the <see cref="LevelData"/> object for the level loaded at the <see cref="SelectedIndex"/> with new data.
        /// </summary>
        /// <param name="levelData">Updated <see cref="LevelData"/> to overwrite the data at the current levels index.</param>
        public readonly void UpdateLevel(LevelData levelData)
        {
            Levels[SelectedIndex] = levelData;
        }
    }
}
