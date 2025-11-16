using UnityEngine;
using System.IO;
using System.Text;

/// <summary>
/// Simple static logger to write CSV/text files to persistentDataPath.
/// Use: Logger.WriteCsv("filename.csv", csvContent);
/// </summary>
public static class Logger
{
    // Folder where logs will be saved
    public static string LogsFolder => Path.Combine(Application.persistentDataPath, "RunnerLogs");

    // Ensure folder exists
    public static void EnsureFolder()
    {
        if (!Directory.Exists(LogsFolder))
        {
            Directory.CreateDirectory(LogsFolder);
        }
    }

    // Write a CSV (or any text) file
    public static void WriteCsv(string filename, string csvContent)
    {
        try
        {
            EnsureFolder();
            string path = Path.Combine(LogsFolder, filename);
            File.WriteAllText(path, csvContent, Encoding.UTF8);
            Debug.Log($"Logger: Saved log to: {path}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Logger: Failed to write file - " + ex.Message);
        }
    }
}
