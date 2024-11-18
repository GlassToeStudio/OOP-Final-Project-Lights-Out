namespace LightsOut
{
    /// <summary>
    /// Provides List of <see cref="LevelData"/> objects and an indexer for accesing <see cref="LevelData"/> objects in List.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// List of <see cref="LevelData"/> objects containing preset data for each level in the game.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <summary>
        /// Get a <see cref="LevelData"/> object for a specific level by index from the <see cref="IDatabase"/> database.
        /// </summary>
        /// <param name="index"> Index of level in list. Ex: Level 1 index is 0</param>
        /// <returns>The <see cref="LevelData"/> at the selected index.</returns>
        public LevelData this[int index] => Levels[index];
    }
}
