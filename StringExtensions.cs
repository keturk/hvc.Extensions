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

using System.Text.RegularExpressions;

namespace hvc.Extensions;

public static class StringExtensions
{
    /// <summary>
    ///     This method returns a substring of the input instance string, starting from the last occurrence of the value
    ///     string or an empty string if emptyIfNotExists is true and value is not found in instance.
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="value"></param>
    /// <param name="emptyIfNotExists">True: Returns an empty string if value is not found in instance</param>
    /// <returns></returns>
    public static String AfterLastOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var lastIndexOf = instance.LastIndexOf(value, StringComparison.Ordinal);

        if (lastIndexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return instance.SafeSubstring(lastIndexOf + value.Length);
    }

    /// <summary>
    ///     Returns portion of instance after first occurrence of value
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="value"></param>
    /// <param name="emptyIfNotExists"></param>
    /// <returns></returns>
    public static String AfterOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var indexOf = instance.IndexOf(value, StringComparison.Ordinal);

        if (indexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return instance.SafeSubstring(indexOf + value.Length);
    }

    /// <summary>
    ///     Returns portion of instance before last occurrence of value.
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="value"></param>
    /// <param name="emptyIfNotExists"></param>
    /// <returns></returns>
    public static String BeforeLastOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var lastIndexOf = instance.LastIndexOf(value, StringComparison.Ordinal);
        if (lastIndexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return lastIndexOf == -1 ? instance : instance.SafeSubstring(0, lastIndexOf);
    }

    /// <summary>
    ///     Returns portion of instance before the first occurrence of value.
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="value"></param>
    /// <param name="emptyIfNotExists"></param>
    /// <returns></returns>
    public static String BeforeOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var indexOf = instance.IndexOf(value, StringComparison.Ordinal);
        if (indexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return indexOf == -1 ? instance : instance.SafeSubstring(0, indexOf);
    }

    /// <summary>
    ///     Returns String.Empty if value is null
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String EmptyIfNull(this String? value)
    {
        return value ?? String.Empty;
    }

    /// <summary>
    ///     Returns provided value only if condition is true.
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public static String If(this String inputString, Boolean condition)
    {
        return condition ? inputString : String.Empty;
    }

    /// <summary>
    ///     Checks if a given string is a valid identifier.
    /// 
    ///     Identifiers must follow certain rules in order to be considered valid.
    /// 
    ///     The regular expression provided in the code checks if the string follows these rules:
    ///         The first character must be a letter, an underscore(_), or a dollar sign($).
    ///         The subsequent characters can be letters, digits, underscores, or dollar signs.
    /// </summary>
    /// <param name="value">String</param>
    /// <returns>True if content of value matches regular expression</returns>
    public static Boolean IsIdentifier(this String value)
    {
        const String identifier = @"^[a-zA-Z_$][a-zA-Z_$0-9]*$";

        return new Regex(identifier).IsMatch(value);
    }

    /// <summary>
    ///     Splits a multi-line string into array of lines
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static String[] Lines(this String source)
    {
        return source.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    }

    /// <summary>
    ///     Throws ArgumentException if value is white space or null.
    ///
    ///     Simplifies checking whether content of a string that should have a value. 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="exceptionMessage">Optional exception message</param>
    /// <returns>Returns input value if it is not null</returns>
    /// <exception cref="ArgumentException"></exception>
    public static String Mandatory(this String? value, String? exceptionMessage = null)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new ArgumentException(exceptionMessage, nameof(value));

        return value;
    }

    public static Boolean IsEqualTo(this String? value1, String? value2,
        StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
    {
        return (!String.IsNullOrWhiteSpace(value1) || String.IsNullOrWhiteSpace(value2)) &&
               (String.IsNullOrWhiteSpace(value1) || !String.IsNullOrWhiteSpace(value2)) &&
               String.Equals(value1, value2, stringComparison);
    }

    /// <summary>
    ///     Makes sure Substring works in boundaries
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="startIndex"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static String SafeSubstring(this String instance, Int32 startIndex, Int32 length = Int32.MaxValue)
    {
        return new String(instance.Skip(startIndex).Take(length).ToArray());
    }

    /// <summary>
    ///     Returns a string array with value appended to the values array
    /// </summary>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static String[] ToStringArray(this String value, params String[] values)
    {
        var listOfValues = new List<String> { value };

        listOfValues.AddRange(values);

        return listOfValues.ToArray();
    }

    /// <summary>
    ///     Converts a string to String Array with one item.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String[] ToStringArray(this String? value)
    {
        return new[] { value ?? String.Empty };
    }

    /// <summary>
    ///     Write contents of a string to file.
    ///
    ///     If skipIfExists is true, it doesn't override the contents of the file.
    ///
    ///     This method also creates subfolder if it does not exists.
    /// </summary>
    /// <param name="fileContent">Content to be written to file</param>
    /// <param name="outputFilename">Name of file</param>
    /// <param name="skipIfExists">If true and file already exists, it will return without modifying existing file</param>
    /// <exception cref="ArgumentException"></exception>
    public static void WriteToFile(this String fileContent, String outputFilename, Boolean skipIfExists = false)
    {
        if (File.Exists(outputFilename) && skipIfExists)
            return;

        var fileFolder = Path.GetDirectoryName(outputFilename) ?? 
                         throw new ArgumentException($"Couldn't retrieve directory name from '{outputFilename}'!", nameof(outputFilename));

        if (!Directory.Exists(fileFolder))
            Directory.CreateDirectory(fileFolder);

        File.WriteAllText(outputFilename, fileContent);
    }
}