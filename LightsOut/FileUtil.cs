using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        internal static readonly string RESOURCES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\");
        internal static readonly string LEVELS = Path.Combine(RESOURCES, "Levels\\");

        internal static string GetFile(string fileName)
        {
            return Path.Combine(LEVELS, fileName);
        }

        internal static string[] GetFiles(string dir)
        {
            return Directory.GetFiles(dir);
        }
    }
}
