namespace LightsOut
{
    public class UserData : LevelDatabase
    {
        int CurrentLevel = 0;
        int[] BoardState => Levels[CurrentLevel].Board;


        public UserData() { }
    }
}
