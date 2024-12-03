namespace ConsoleApp.Utils;

public static class InputReader
{
    public static string[] ReadLines(string fileName)
    {
        return File.ReadAllLines(Path.Combine("Input", fileName));
    }
}
