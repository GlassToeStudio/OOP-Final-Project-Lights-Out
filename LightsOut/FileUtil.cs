using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        internal static readonly string RESOURCES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\");
        internal static readonly string LEVELS = Path.Combine(RESOURCES, "Levels\\");

        internal static string GetFile(string jsonFile)
        {
            return Path.Combine(RESOURCES, jsonFile);
        }

        internal static string[] GetFiles(string dir)
        {
            return Directory.GetFiles(dir);
        }
    }
}
