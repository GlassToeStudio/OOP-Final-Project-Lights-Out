namespace LightsOut
{
    public class UserDatabase : IDatabase
    {
        public List<LevelData> Levels { get; set; }
        public int SelectedIndex { get; set; } = 0;
        public int MaxIndex { get; set; } = 0;
        public LevelData CurrentLevel => Levels[SelectedIndex];
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

        public UserDatabase()
        {
            Levels = [];
        }

        public void AddLevel(LevelData levelData)
        {
            Levels.Add(levelData);
        }
    }

    public class DataHandler()
    {
        private UserDatabase user = new UserDatabase().LoadUserDatabase();
        private LevelDatabase game = new LevelDatabase().LoadLevelDatabase();

        public List<LevelData> Levels => game.Levels;
        public int SelectedIndex => user.SelectedIndex;
        public int MaxIndex => user.MaxIndex;
        public LevelData CurrentLevel => user.CurrentLevel;
        public LevelData Level
        {
            get
            {
                return new LevelData(user.CurrentLevel);
            }
        }
        

        public void IncrementLevel()
        {
            if( (user.MaxIndex > user.SelectedIndex)&& (user.SelectedIndex + 1 < game.Levels.Count - 1))
            {
                user.SelectedIndex++;
            }

        }

        public void DecrementLevel()
        {
            if (user.SelectedIndex > 0)
            {
                user.SelectedIndex--;
            }
        }

        public LevelData UpdateUserData( int moves)
        {
            if((MaxIndex + 1 < Levels.Count-1) &&(MaxIndex == SelectedIndex))
            {
                user.MaxIndex += 1;
                user.AddLevel(Levels[MaxIndex]);
            }

            var levelData =  new LevelData(Levels[SelectedIndex], moves);
            if (CurrentLevel.BestScore > levelData.BestScore)
            {
                user[SelectedIndex]=levelData;
            }
            return levelData;
        }

        public void SaveUserData(LevelData levelData)
        {
            FileUtil.SaveUserData(user, levelData);
            //FileUtil.SaveGameData(game, levelData);
        }

#if DEBUG
        public void UpdateIndex(int index) {
            user.SelectedIndex = index;
        }
#endif
    }
}
