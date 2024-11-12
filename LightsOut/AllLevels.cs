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

        #region GetIndex
        //public int this[LevelData ld] => FindNameIndex(ld);     

        //private int FindNameIndex(LevelData ld)
        //{
        //    return Array.FindIndex(Levels, x => x.ToString() == ld.ToString());

        //    throw new ArgumentOutOfRangeException(
        //        nameof(ld),
        //        $"Name {ld} is not supported.\nName input must be in the form Levels x, etc");
        //}
        #endregion
    }
}
