using System.Reflection;

namespace ConsoleApp.Utils;

public static class InputReader
{
    public static string[] ReadLines(string fileName, string dayFolder)
    {
        // Get the location of the executing assembly
        var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // Go up to the project root (assumes "bin/{configuration}/net8.0" folder)
        var projectRoot = Path.Combine(assemblyLocation ?? "", "../../../../");

        // Normalize the path to handle any extra separators
        projectRoot = Path.GetFullPath(projectRoot);

        var filePath = Path.Combine(projectRoot, "ConsoleApp/Days", dayFolder, fileName);

        // Ensure the file exists
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Input file not found at {filePath}");
        }

        // Return the lines from the file
        return File.ReadAllLines(filePath);
    }
}