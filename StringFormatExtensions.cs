using System.Text;
using System.Text.RegularExpressions;

namespace hvc.Extensions;

public static class StringFormatExtensions
{
    public static String CamelCase(this String instance)
    {
        return String.IsNullOrWhiteSpace(instance) ? "" : $"{instance[..1].ToLower()}{instance[1..]}";
    }

    public static String Hyphenate(this String value)
    {
        return value.Replace(' ', '-');
    }

    public static String PrivateMemberNaming(this String instance)
    {
        return String.IsNullOrWhiteSpace(instance) ? "_" : $"_{instance[..1].ToLower()}{instance[1..]}";
    }

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