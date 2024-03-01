using System.IO;

namespace LucasHelper;

public class LocalLog
{
    private LocalLog() { }

    private LocalLog(string fullPath)
    {
        FileName = fullPath;
    }

    public readonly string FileName = string.Empty;

    public static LocalLog GenericLog(string path, string fileName)
    {
        var fullPath = Path.Combine(path, fileName);

        return GenericLog(fullPath);
    }

    public static LocalLog GenericLog()
    {
        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/DebugLog({DateTime.Now:yyyy-MM-dd}).txt");
        return GenericLog(fullPath);
    }

    public static LocalLog GenericLog(string filePath)
    {
        var fullPath = filePath;
        if (!Path.IsPathRooted(fullPath))
        {
            fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fullPath);
        }

        var path = Path.GetDirectoryName(fullPath);
        if (!Directory.Exists(path))  //不存在文件夹，创建
        {
            Directory.CreateDirectory(path);  //创建新的文件夹
        }

        if (!File.Exists(fullPath))
        {
            var logFile = File.Create(fullPath);
            logFile.Close();
        }
        return new LocalLog(fullPath);
    }

    public void Log(string content)
    {
        File.AppendAllText(FileName, content);
    }

    public async Task LogAsync(string content)
    {
        await File.AppendAllTextAsync(FileName, content + "\r\n");
    }
}
