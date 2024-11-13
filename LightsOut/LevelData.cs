namespace LightsOut
{
    /// <summary>
    /// Struct containing data for each level.
    /// </summary>
    public struct LevelData
    {
        /// <summary>The number of this level. Ex: Level 1.</summary>
        public int Level;
        /// <summary>Size of board Ex: Size = 4 => 4x4 board.</summary>
        public int Size;
        /// <summary>Minimum moves required to complete the level.</summary>
        public int MinMoves;
        /// <summary>Integer array representing a data model of the Board.</summary>
        public int[] Board = [];
        /// <summary>True of this level has been completed, false otherwise.</summary>
        public bool Completed = false;
        /// <summary>Return "Level {level}" Ex: "Level 1".</summary>
        public readonly string Name => $"Level {Level}";

        /// <summary>Default constructor.</summary>
        public LevelData() { }

        /// <summary>
        /// Construct a LevelData object with Level, Size, and Minimum moves.
        /// </summary>
        /// <param name="level">This levels index.</param>
        /// <param name="size">Size of board Ex: Size=4 => 4x4 board.</param>
        /// <param name="minMoves">Min moves required to complete the level.</param>
        public LevelData(int level, int size, int minMoves)
        {
            Level = level;
            Size = size;
            MinMoves = minMoves;
            Board = new int[Size * Size];
        }

        /// <summary>
        /// Construct a new LevelData object from an existing LevelData object.
        /// </summary>
        /// <param name="levelData">Existing LevelData object.</param>
        public LevelData(LevelData levelData)
        {
            Level = levelData.Level;
            Size = levelData.Size;
            MinMoves = levelData.MinMoves;
            Board = new int[Size * Size];

            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = levelData.Board[i];
            }
        }

        /// <summary>
        /// Update Board data to match the View data. 
        /// </summary>
        /// <param name="lights">Array of Lights that is the interactive View.</param>
        public readonly void UpdateBoard(Light[] lights)
        {
            foreach (var light in lights)
            {
                Board[light.Index] = (int)light.State;
            }
        }

        /// <summary>
        /// The fully qualified type name.
        /// </summary>
        /// <returns>Human readable string of the LevelData fields.</returns>
        public override readonly string ToString()
        {
            return $"Level_{Level}_{Size}x{Size}_Goal_{MinMoves}";
        }
    }
}
