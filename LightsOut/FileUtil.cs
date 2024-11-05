using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        internal static readonly string RESOURCES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\");
        internal static readonly string LEVELS = Path.Combine(RESOURCES, "Levels\\");
        internal static readonly string SOUNDS = Path.Combine(RESOURCES, "Sounds\\");

        internal static string GetLevelFile(string fileName)
        {
            return Path.Combine(LEVELS, fileName);
        }

        internal static string GetSoundFile(string fileName)
        {
            return Path.Combine(SOUNDS, fileName);
        }

        internal static string[] GetFileFromLevelsFolder()
        {
            return Directory.GetFiles(LEVELS);
        }
    }
}
