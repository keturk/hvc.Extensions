﻿// MIT License
//
// Copyright (c) 2022 Kamil Ercan Turkarslan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Text.RegularExpressions;

namespace hvc.Extensions;

public static class StringExtensions
{
    public static String AfterLastOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var lastIndexOf = instance.LastIndexOf(value, StringComparison.Ordinal);

        if (lastIndexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return instance.SafeSubstring(lastIndexOf + value.Length);
    }

    public static String AfterOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var indexOf = instance.IndexOf(value, StringComparison.Ordinal);

        if (indexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return instance.SafeSubstring(indexOf + value.Length);
    }

    public static String BeforeLastOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var lastIndexOf = instance.LastIndexOf(value, StringComparison.Ordinal);
        if (lastIndexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return lastIndexOf == -1 ? instance : instance.SafeSubstring(0, lastIndexOf);
    }

    public static String BeforeOccurrenceOf(this String instance, String value, Boolean emptyIfNotExists = false)
    {
        var indexOf = instance.IndexOf(value, StringComparison.Ordinal);
        if (indexOf == -1 && emptyIfNotExists)
            return String.Empty;

        return indexOf == -1 ? instance : instance.SafeSubstring(0, indexOf);
    }

    public static String EmptyIfNull(this String? value)
    {
        return value ?? String.Empty;
    }

    public static String If(this String inputString, Boolean condition)
    {
        return condition ? inputString : String.Empty;
    }

    public static Boolean IsIdentifier(this String value)
    {
        return new Regex(@"^[a-zA-Z_$][a-zA-Z_$0-9]*$").IsMatch(value);
    }

    public static String[] Lines(this String source)
    {
        return source.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    }

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

    public static String SafeSubstring(this String instance, Int32 startIndex, Int32 length = Int32.MaxValue)
    {
        return new String(instance.Skip(startIndex).Take(length).ToArray());
    }

    public static String[] ToStringArray(this String value, params String[] values)
    {
        var listOfValues = new List<String> { value };

        listOfValues.AddRange(values);

        return listOfValues.ToArray();
    }

    public static String[] ToStringArray(this String? value)
    {
        return new[] { value ?? String.Empty };
    }

    public static void WriteToFile(this String fileContent, String outputFilename, Boolean skipIfExists = false)
    {
        if (File.Exists(outputFilename) && skipIfExists)
            return;

        var fileFolder =
            Path.GetDirectoryName(outputFilename) ?? throw new ArgumentException(
                $"Couldn't retrieve directory name from '{outputFilename}'!",
                nameof(outputFilename));

        if (!Directory.Exists(fileFolder))
            Directory.CreateDirectory(fileFolder);

        File.WriteAllText(outputFilename, fileContent);
    }
}