namespace LightsOut
{
    /// <summary>
    /// Struct containing data for each level.
    /// </summary>
    public struct LevelData
    {
        /// <summary>Return "Level {level}" Ex: "Level 1".</summary>
        public readonly string Name => $"Level {Level}";
        /// <summary>The number of this level. Ex: Level 1.</summary>
        public int Level;
        /// <summary>Size of board Ex: Size = 4 => 4x4 board.</summary>
        public int Size;
        /// <summary>Minimum moves required to complete the level.</summary>
        public int MinMoves;
        /// <summary>The minimum number of moves used to beat this level. 9000 to begin.</summary>
        public int BestScore = 9000;
        /// <summary>The number of Stars earned for this level. 0 to begin.</summary>
        public int Stars = 0;
        /// <summary>Integer array representing a data model of the Board.</summary>
        public int[] Board = [];

        /// <summary>
        /// Default constructor.
        /// </summary>
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
        /// Construct a new LevelData object from an existing levelData object and set
        /// its BestScore and Numbner of stars fields from the number of moves taken to
        /// complete the level.
        /// </summary>
        /// <param name="levelData">The current LevelData object loaded for this Level.</param>
        /// <param name="moves">The number of moves taken to beat this level.</param>
        public LevelData(LevelData levelData, int moves)
        {
            Level = levelData.Level;
            Size = levelData.Size;
            MinMoves = levelData.MinMoves;
            Board = new int[Size * Size];

            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = levelData.Board[i];
            }


            if (moves < BestScore)
            {
                BestScore = moves;
            }

            if (BestScore <= MinMoves)
            {
                Stars = 3;
            }
            else if (BestScore <= MinMoves + 3)
            {
                Stars = 2;
            }
            else if (BestScore <= MinMoves + 6)
            {
                Stars = 1;
            }
            else
            {
                Stars = 3;
            }
        }

        /// <summary>
        /// Construct a new LevelData object from an existing LevelData object.
        /// A new Board is created based on the passed in Board data.
        /// </summary>
        /// <param name="levelData">Existing LevelData object.</param>
        public LevelData(LevelData levelData)
        {
            Level = levelData.Level;
            Size = levelData.Size;
            MinMoves = levelData.MinMoves;
            Board = new int[Size * Size];
            BestScore = levelData.BestScore;
            Stars = levelData.Stars;

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
            return $"Level_{Level}_{Size}x{Size}_Goal_{MinMoves}_Best Score_{BestScore}_Stars_{Stars}";
        }
    }
}
