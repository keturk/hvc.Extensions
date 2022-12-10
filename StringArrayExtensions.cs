using System.Text;

namespace hvc.Extensions;

public static class StringArrayExtensions
{
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

    public static Boolean IsEmpty(this String[] values)
    {
        return !values.Any();
    }

    public static String[] Sort(this String[] values)
    {
        var clonedValues = new String[values.Length];

        values.CopyTo(clonedValues, 0);

        Array.Sort(clonedValues, StringComparer.InvariantCultureIgnoreCase);

        return clonedValues;
    }

    public static String[] Quote(this List<String> values)
    {
        return Quote(values.ToArray());
    }

    public static String[] Quote(this String[] values)
    {
        var quotedValues = new String[values.Length];

        var index = 0;
        foreach (var value in values)
            quotedValues[index++] = $"\"{value.Unquote()}\"";

        return quotedValues;
    }

    public static String[] CamelCase(this List<String> values)
    {
        return CamelCase(values.ToArray());
    }

    public static String[] CamelCase(this String[] values)
    {
        var returnValues = new String[values.Length];

        var index = 0;
        foreach (var value in values)
            returnValues[index++] = value.CamelCase();

        return returnValues;
    }

    public static String[] SnakeCase(this String[] values)
    {
        var returnValues = new String[values.Length];

        var index = 0;
        foreach (var value in values)
            returnValues[index++] = value.SnakeCase();

        return returnValues;
    }
}