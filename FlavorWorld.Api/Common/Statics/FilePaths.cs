using System.Reflection;

namespace FlavorWorld.Api.Common.Constants.Statics;

public static class FilePaths
{
    private static string currentDirectory = Directory.GetCurrentDirectory();
    private static string parentDirectory = Directory.GetParent(currentDirectory).FullName;
    private static string logsPath = Path.Combine(parentDirectory, "Logs");
    private static IEnumerable<string> txtFiles = Directory.EnumerateFiles(logsPath, "*.txt");


    public static List<string> txtLogFiles = txtFiles.ToList();
}