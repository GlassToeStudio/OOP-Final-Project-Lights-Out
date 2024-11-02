using Newtonsoft.Json;

namespace LightsOut
{
    internal class FileUtil
    {
        internal static string GetFileLocation(string jsonFile)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\") + jsonFile;
        }
    }
}
