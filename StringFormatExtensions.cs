﻿// MIT License
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
using System.Text.RegularExpressions;

namespace hvc.Extensions;

public static class StringFormatExtensions
{
    /// <summary>
    ///     Converts the input String to camel case, which means that the first letter of the string is lowercase and the rest
    ///     of the string is unmodified. If the input string is null, empty, or consists only of whitespace, the method returns
    ///     an empty string.
    /// </summary>
    /// <param name="instance">Input string</param>
    /// <returns>Output with first character lower case</returns>
    public static String CamelCase(this String instance)
    {
        return String.IsNullOrWhiteSpace(instance) ? "" : $"{instance[..1].ToLower()}{instance[1..]}";
    }

    /// <summary>
    ///     Replaces all occurrences of the space character in the value string with the hyphen character '-', and then
    ///     returns the resulting string.
    /// </summary>
    /// <param name="value">Input string which may contain space character(s)</param>
    /// <returns>Output string with '-' instead of occurrences of ' '</returns>
    public static String Hyphenate(this String value)
    {
        return value.Replace(' ', '-');
    }

    /// <summary>
    ///     Returns the input string with the first character converted to lowercase and an underscore prepended to it. For
    ///     example, if the input string is "FooBar", the method would return "_fooBar".
    /// </summary>
    /// <param name="instance">Input</param>
    /// <returns>Camel case string starting with '_' </returns>
    public static String PrivateMemberNaming(this String instance)
    {
        return String.IsNullOrWhiteSpace(instance) ? "_" : $"_{instance[..1].ToLower()}{instance[1..]}";
    }

    /// <summary>
    ///     Removes all occurrences of subString and trims spaces.
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="subString"></param>
    /// <returns></returns>
    public static String TrimSubString(this String instance, String subString)
    {
        return instance.Replace(subString, String.Empty).Trim();
    }

    public static String Unquote(this String? value)
    {
        return (value ?? String.Empty).Trim().Trim('"').Trim().Trim('\'').Trim();
    }

    public static String Quote(this String value)
    {
        return $"\"{value}\"";
    }

    public static String Prepend(this String inputString, String? value)
    {
        return inputString.Insert(0, value ?? String.Empty);
    }

    /// <summary>
    ///     Converts the input String to snake case, which means that the string is in lowercase and words are separated by
    ///     underscore characters '_'. If the input string is null, empty, or consists only of whitespace, the method returns
    ///     the input string as is.
    /// </summary>
    /// <param name="instance">Input</param>
    /// <returns>
    ///     String.Empty if input is null.
    ///     Returns snake case formatted string.
    /// </returns>
    public static String SnakeCase(this String instance)
    {
        if (String.IsNullOrWhiteSpace(instance))
            return instance;

        var result = new StringBuilder();

        var oneTimeFlag = new OneTimeFlag();
        var chars = instance.ToCharArray();

        for (var i = 0; i < chars.Length; i++)
        {
            var isFirstTime = oneTimeFlag.IsFirstTime();
            var prevChar = i > 0 ? chars[i - 1] : Char.MinValue;
            var currentChar = chars[i];
            var nextChar = i < chars.Length - 1 ? chars[i + 1] : Char.MinValue;
            var isLastChar = i == chars.Length - 1;

            if (Char.IsUpper(currentChar))
                if ((!Char.IsUpper(prevChar) && !isFirstTime) ||
                    (Char.IsUpper(prevChar) && !Char.IsUpper(nextChar) && !isLastChar))
                    if (prevChar != '_')
                        result.Append('_');

            result.Append(Char.ToLower(currentChar));
        }

        return result.ToString();
    }

    public static String ToFriendlyCase(this String value)
    {
        return Regex.Replace(value, "(?!^)([A-Z])", " $1");
    }

    public static String ToTitleCase(this String? value)
    {
        return String.IsNullOrWhiteSpace(value) ? String.Empty : $"{Char.ToUpper(value[0])}{value[1..]}";
    }
}