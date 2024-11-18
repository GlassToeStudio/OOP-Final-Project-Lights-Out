namespace LightsOut
{
    /// <summary>
    /// Container class for all pre-made levels in a List of <see cref="LevelData"/>. Implements <see cref="IDatabase"/>.
    /// <para>The  <see cref="LevelDatabase"/> holds data for each pre-made Level in the game.
    /// The data is loaded at startup and new levels are initialized with their respective
    /// <see cref="LevelData"/> objects information.</para>
    /// </summary>
    public struct LevelDatabase : IDatabase
    {
        /// <summary>
        /// List of all pre-made <see cref="LevelData"/>. Levels are initialized with this data.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <inheritdoc/>
        public readonly LevelData this[int index] => Levels[index];

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelDatabase"/> class.
        /// </summary>
        public LevelDatabase()
        {
            Levels = [];
        }
    }
}
