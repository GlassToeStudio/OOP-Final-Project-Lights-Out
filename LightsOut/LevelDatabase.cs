namespace LightsOut
{
    /// <summary>
    /// Container for all LevelData with helper properties for level navigation.
    /// </summary>
    public class LevelDatabase
    {
        /// <summary>
        /// Array of all premade LevelData. Levels are initialized with this data.
        /// </summary>
        public LevelData[] Levels;
        /// <summary>
        /// The current index of the selected level in the database.
        /// </summary>
        public int SelectedIndex { get; set; }
        /// <summary>
        /// Number of levels stored in database
        /// </summary>
        public int Count => Levels.Length;
        /// <summary>
        /// Next index in database.
        /// </summary>
        public int Next => Math.Min(SelectedIndex + 1, this.Count - 1);
        /// <summary>
        /// Previous index in database
        /// </summary>
        public int Previous => Math.Max(SelectedIndex - 1, 0);
        /// <summary>
        /// The current item selected from database.
        /// </summary>
        public LevelData SelectedItem => this[SelectedIndex];

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LevelDatabase()
        {
            Levels = [];
        }

        /// <summary>
        /// Get level from database by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LevelData this[int index]
        {
            get
            {
                SelectedIndex = index;
                return Levels[SelectedIndex];
            }
        }
    }
}
