namespace hvc.Extensions;

public static class TypeExtensions
{
    public static Boolean CanBeTreatedAsType(this Type? currentType, Type? typeToCompareWith)
    {
        return currentType != null && typeToCompareWith != null && typeToCompareWith.IsAssignableFrom(currentType);
    }

    public static List<Type> GetTypesInHierarchy(this Type type, Type baseType)
    {
        var types = new List<Type>();

        for (var currentType = type; currentType != null; currentType = currentType.BaseType)
        {
            types.Add(currentType);
            
            if (currentType == baseType)
                break;
        }

        types.Reverse();

        return types;
    }
}