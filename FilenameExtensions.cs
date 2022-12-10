namespace hvc.Extensions;

public static class FilenameExtensions
{
    public static Boolean IsPath(this String value)
    {
        return Path.IsPathFullyQualified(Path.GetFullPath(value));
    }

    public static Boolean IsExistingFile(this String value)
    {
        return File.Exists(value);
    }

    public static Boolean IsExistingFolder(this String value)
    {       
        return Directory.Exists(value);
    }

    public static String CurrentFolder(this String value)
    {
        var currentFolder = Directory.GetCurrentDirectory();

        return Path.Join(currentFolder, value);
    }

    public static String FullPath(this String value)
    {
        return Path.GetFullPath(value);
    }

    public static String Folder(this String value)
    {
        var folder = value.FullPath();

        return Path.GetDirectoryName(folder)
               ?? throw new DirectoryNotFoundException($"Folder '{folder}' not found!");
    }

    public static String Filename(this String value)
    {
        return Path.GetFileName(value);
    }

    public static String[] Files(this String fullFilePath)
    {
        var filenamePattern = Path.GetFileName(fullFilePath);
        var folder = fullFilePath.Replace(filenamePattern, String.Empty);

        var files = new List<String>();

        try
        {
            var foundFiles = Directory.EnumerateFiles(folder, filenamePattern);

            files.AddRange(foundFiles);
        }
        catch (Exception e)
        {
            // ignored
        }

        return files.ToArray();
    }
}