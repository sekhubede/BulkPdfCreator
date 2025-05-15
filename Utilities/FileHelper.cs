using System.Text.RegularExpressions;

namespace BulkPdfCreator.Utilities;

public static class FileHelper
{
    public static string SanitizeFileName(string name)
    {
        var invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
        var regex = new Regex($"[{invalidChars}]");
        var cleanName = regex.Replace(name, "_");

        return cleanName.Length > 100 ? cleanName.Substring(0, 100) : cleanName;
    }
}
