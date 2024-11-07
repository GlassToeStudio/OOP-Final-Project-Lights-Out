using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace LightsOut
{
    public struct LevelData
    {
        public int Level;
        public int Size;
        public int MinMoves;
        public int[] Board = [];

        public readonly string Name => $"Level {Level}";

        public LevelData() { }

        public LevelData(int level, int size, int minMoves)
        {
            Level = level;
            Size = size;
            MinMoves = minMoves;
            Board = new int[Size * Size];
        }

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

        public readonly void UpdateBoard(Light[] lights)
        {
            foreach (var light in lights)
            {
                Board[light.index] = (int)light.State;
            }
        }

        //public override readonly string ToString()
        //{
        //    return $"Level: {Level}, Size: {Size}, Goal: {MinMoves}";
        //}
    }
}
