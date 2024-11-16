namespace LightsOut
{
    /// <summary>
    /// Class for handling game data. 
    /// Loading data from disk,
    /// Incrementing and decrement level,
    /// Updating user progress,
    /// Saving data to disk.
    /// </summary>
    public class DataHandler()
    {
        bool manualLoad = false;
        /// Load UserDatabase and GameDatabase from disk.
        private readonly UserDatabase user = new UserDatabase().LoadUserDatabase();
        private LevelDatabase game = new LevelDatabase().LoadLevelDatabase();

        /// <summary>
        /// Get the GameDatabase object which holds all pre-made loaded levels.
        /// </summary>
        public LevelDatabase Game => game;
        /// <summary>
        /// Get the pre-made, loaded levels from the GameDatabase.
        /// </summary>
        public List<LevelData> Levels => game.Levels;
        /// <summary>
        /// The current index of the UserDatabase.
        /// </summary>
        public int SelectedIndex => user.SelectedIndex;
        /// <summary>
        /// The max index of the UserDatabase, i.e the highest unlocked level.
        /// </summary>
        public int MaxIndex => user.MaxIndex;
        /// <summary>
        /// The level currenttly loaded from the UserDatabase.
        /// </summary>
        public LevelData CurrentLevel => user.CurrentLevel;

        /// <summary>
        /// Get a new LevelData object of the current loaded level from the UserDatabse.
        /// </summary>
        public LevelData Level
        {
            get
            {
                try
                {
                    manualLoad = false;
                    return new LevelData(user.CurrentLevel);
                }
                catch
                {
                    manualLoad = true;
                    return Levels[SelectedIndex];
                }
            }
        }
        
        /// <summary>
        /// Increment the SelectedIndex by one, this will progress to the next unlocked level from the UserDatabase.
        /// </summary>
        public void IncrementLevel()
        {
            if( (user.MaxIndex > user.SelectedIndex)&& (user.SelectedIndex + 1 < game.Levels.Count - 1))
            {
                user.SelectedIndex++;
            }

        }

        /// <summary>
        /// Decrement the SelectedIndex by one, this will regress to the previous level from the UserDatabase.
        /// </summary>
        public void DecrementLevel()
        {
            if (user.SelectedIndex > 0)
            {
                user.SelectedIndex--;
            }
        }

        /// <summary>
        /// Update the LevelData for the current loaded level from the UserDatabase.
        /// This will update the BestScore and Stars fields of the leveldata and save
        /// it to the UserDatabase.
        /// </summary>
        /// <param name="moves">The number of moves taken to beat this level.</param>
        /// <returns>A new LevelData object with updated BestScore and Stars.</returns>
        public LevelData UpdateUserData( int moves)
        {
            if((MaxIndex + 1 < Levels.Count-1) &&(MaxIndex == SelectedIndex))
            {
                user.MaxIndex += 1;
                user.AddLevel(Levels[MaxIndex]);
            }
            
            var levelData =  new LevelData(Levels[SelectedIndex], moves);
            if (manualLoad)
            {
                return levelData;
            }

            if (CurrentLevel.BestScore > levelData.BestScore)
            {
                user[SelectedIndex] = levelData;
            }

            return levelData;
        }

        /// <summary>
        /// Write any updated LevelData in the UserDatabase to disk.
        /// </summary>
        public void SaveUserData()
        {
            if (manualLoad)
            {
                return;
            }
            FileUtil.SaveUserData(user);
        }

#if DEBUG
        /// <summary>
        /// Manually change the SelectedIndex to load a level.
        /// </summary>
        /// <param name="index"></param>
        public void UpdateIndex(int index) {
            user.SelectedIndex = index;
        }
#endif
    }
}
