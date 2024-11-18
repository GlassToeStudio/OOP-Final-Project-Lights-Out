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
        /// Load UserDatabase and GameDatabase from disk.
        private readonly UserDatabase user = new UserDatabase().LoadUserDatabase();
        private LevelDatabase game = new LevelDatabase().LoadLevelDatabase();

#if DEBUG
        /// <summary>
        /// Bypass editing and saving user data when we manually load a level.
        /// If we load a level manually, i.e. from the dropdown box, we may have
        /// loaded a level that is not unlocked yet. We do not want to perform
        /// the usual operations of the user data if we do this. So we can bypass
        /// savind data, and editing user data by use of this flag.
        /// </summary>
        private bool manualLoad = false;
#endif

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
        /// The level currently loaded from the UserDatabase.
        /// </summary>
        public LevelData CurrentLevel => user.CurrentLevel;
        /// <summary>
        /// Get a new LevelData object of the current loaded level from the UserDatabase.
        /// </summary>
        public LevelData Level
        {
            get
            {
                /* Normally we load the level based on the SelectedIndex that is
                 * Controlled through UI buttons and has checks in place to oly
                 * attempt to load a valid unlocked level.
                 * Manually loading a level would cause and index out of range error.
                 * We can check for that here and set the manualLoad flag to true if so.
                 */
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
            if ((user.MaxIndex > user.SelectedIndex) && (user.SelectedIndex + 1 < game.Levels.Count - 1))
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
        /// This will update the BestScore and Stars fields of the levelData and save
        /// it to the UserDatabase.
        /// </summary>
        /// <param name="moves">The number of moves taken to beat this level.</param>
        /// <returns>A new LevelData object with updated BestScore and Stars.</returns>
        public LevelData UpdateUserData(int moves)
        {
            if ((MaxIndex + 1 < Levels.Count) && (MaxIndex == SelectedIndex))
            {
                user.MaxIndex += 1;
                user.AddLevel(Levels[MaxIndex]);
            }

            var levelData =  new LevelData(Levels[SelectedIndex], moves);
#if DEBUG
            if (manualLoad)
            {
                return levelData;
            }
#endif

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
#if DEBUG
            if (manualLoad)
            {
                return;
            }
#endif
            FileUtil.SaveUserData(user);
        }

#if DEBUG
        /// <summary>
        /// Manually change the SelectedIndex to load a level.
        /// </summary>
        /// <param name="index">index in Levels List that we wish to load.</param>
        public void UpdateIndex(int index)
        {
            user.SelectedIndex = index;
        }
#endif
    }
}
