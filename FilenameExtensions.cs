// MIT License
//
// Copyright (c) 2022 Kamil Ercan Turkarslan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
namespace hvc.Extensions;

public static class FilenameExtensions
{
    /// <summary>
    ///    Checks whether content of value is a valid path.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Boolean IsPath(this String value)
    {
        return Path.IsPathFullyQualified(Path.GetFullPath(value));
    }

    /// <summary>
    ///     Checks whether content of value is an existing filename.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Boolean IsExistingFile(this String value)
    {
        return File.Exists(value);
    }

    /// <summary>
    ///     Checks whether content of value is an existing directory.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Boolean IsExistingFolder(this String value)
    {
        return Directory.Exists(value);
    }

    /// <summary>
    ///     Appends content of value to the end of content of path with a directory separator.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String CurrentFolder(this String value)
    {
        var currentFolder = Directory.GetCurrentDirectory();

        return Path.Join(currentFolder, value);
    }

    /// <summary>
    ///     Returns full path from provided value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String FullPath(this String value)
    {
        return Path.GetFullPath(value);
    }

    /// <summary>
    ///     Returns absolute directory path from provided value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="DirectoryNotFoundException"></exception>
    public static String Folder(this String value)
    {
        var folder = value.FullPath();

        return Path.GetDirectoryName(folder)
               ?? throw new DirectoryNotFoundException($"Folder '{folder}' not found!");
    }

    /// <summary>
    ///     Returns filename portion of content of value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String Filename(this String value)
    {
        return Path.GetFileName(value);
    }


    /// <summary>
    ///     Returns an array of file names from provided path which may have wildcards.
    /// </summary>
    /// <param name="fullFilePath"></param>
    /// <returns></returns>
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
        catch (Exception)
        {
            // ignored
        }

        return files.ToArray();
    }
}