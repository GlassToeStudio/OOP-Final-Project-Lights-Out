namespace LightsOut
{
    public class AllLevels
    {
        public LevelData[] Levels;
        public int SelectedIndex { get; set; }
        public int Count => Levels.Length;
        public int Next => Math.Min(SelectedIndex + 1, this.Count - 1);
        public int Previous => Math.Max(SelectedIndex - 1, 0);
        public LevelData SelectedItem => this[SelectedIndex];


        public AllLevels()
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
