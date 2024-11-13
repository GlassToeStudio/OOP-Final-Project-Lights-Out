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
        public int Count => Levels.Length;
        public int Next => Math.Min(SelectedIndex + 1, this.Count - 1);
        public int Previous => Math.Max(SelectedIndex - 1, 0);
        public LevelData SelectedItem => this[SelectedIndex];


        public LevelDatabase()
        {
            Levels = [];
        }


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
