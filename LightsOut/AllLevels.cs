using System.Collections;
using System.Windows.Forms;

namespace LightsOut
{
    public struct AllLevels
    {
        public LevelData[] Levels;
        private int selectedIndex = 0;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }
        public int Count => Levels.Length;
        public LevelData SelectedItem => this[selectedIndex];
        public int Next => Math.Min(selectedIndex+1, this.Count - 1);
        public int Previous => Math.Max(selectedIndex-1, 0);


        public AllLevels()
        {
            Levels = [];
        }


        public LevelData this[int index]
        {
            get
            {
                selectedIndex = index;
                return Levels[index];
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
