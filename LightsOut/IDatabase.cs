namespace LightsOut
{
    public interface IDatabase
    {
        public List<LevelData> Levels { get; set; }
        public LevelData this[int index]
        {
            get
            {
                return Levels[index];
            }
        }
    }
}
