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

using System.Text;

namespace hvc.Extensions;

public static class StringArrayExtensions
{
    /// <summary>
    ///     Combines items of values array into a single string.
    ///     If separator is specified, it adds separator between items.
    ///     If prefix is specified, it adds a prefix to each item.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public static String Combine(this String[] values, String? separator = null, String? prefix = null)
    {
        var sb = new StringBuilder();

        var count = 0;
        foreach (var value in values)
            sb.Append(count++ == 0
                ? $"{prefix ?? String.Empty}{value}"
                : $"{separator} {prefix ?? String.Empty}{value}");

        return sb.ToString();
    }

    /// <summary>
    ///     Returns true if values array is empty.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static Boolean IsEmpty(this String[] values)
    {
        return !values.Any();
    }

    /// <summary>
    ///     Sorts values array into a cloned array without changing order of items in values array.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static String[] Sort(this String[] values)
    {
        var clonedValues = new String[values.Length];

        values.CopyTo(clonedValues, 0);

        Array.Sort(clonedValues, StringComparer.InvariantCultureIgnoreCase);

        return clonedValues;
    }

    /// <summary>
    ///     Adds double quotes to the beginning and end of all items in values.
    /// </summary>
    /// <param name="values"></param>
    /// <returns>String array containing double quoted values</returns>
    public static String[] Quote(this List<String> values)
    {
        return Quote(values.ToArray());
    }

    /// <summary>
    ///     Adds double quotes to each item of values array. If item is already quoted or double quoted, it removes that quotation and
    ///     double quotes it.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static String[] Quote(this String[] values)
    {
        var quotedValues = new String[values.Length];

        var index = 0;
        foreach (var value in values)
            quotedValues[index++] = $"\"{value.Unquote()}\"";

        return quotedValues;
    }

    /// <summary>
    ///     Calls StringFormatExtensions.CamelCase method for each item of values list
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static String[] CamelCase(this List<String> values)
    {
        return CamelCase(values.ToArray());
    }

    /// <summary>
    ///     Calls StringFormatExtensions.CamelCase method for each item of values array
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static String[] CamelCase(this String[] values)
    {
        var returnValues = new String[values.Length];

        var index = 0;
        foreach (var value in values)
            returnValues[index++] = value.CamelCase();

        return returnValues;
    }

    /// <summary>
    ///     Calls StringFormatExtensions.SnakeCase method for each item of values array
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static String[] SnakeCase(this String[] values)
    {
        var returnValues = new String[values.Length];

        var index = 0;
        foreach (var value in values)
            returnValues[index++] = value.SnakeCase();

        return returnValues;
    }
}