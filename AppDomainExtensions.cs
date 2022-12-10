namespace hvc.Extensions;

public static class AppDomainExtensions
{
    /// <summary>
    ///     Get All Classes with specified attribute in an AppDomain
    /// </summary>
    /// <param name="appDomain">AppDomain</param>
    /// <param name="attributeType">Attribute type that is </param>
    /// <returns></returns>
    public static IEnumerable<Type> GetClassesByAttribute(this AppDomain appDomain, Type attributeType)
    {
        return (from assembly in appDomain.GetAssemblies()
            from type in assembly.GetTypes()
            let attributes = type.GetCustomAttributes(false)
            from attr in attributes
            where attr.GetType() == attributeType
            select type).ToList();
    }

    public static Type? GetSubClass(this AppDomain appDomain, Type baseType, String name, String prefix = "",
        String suffix = "")
    {
        return (from assembly in appDomain.GetAssemblies()
            let assemblyName = assembly.GetName().Name
            where assemblyName != null && assemblyName.StartsWith(prefix)
            from type in assembly.GetTypes()
            select type).FirstOrDefault(type =>
            type.IsSubclassOf(baseType) && String.Equals(type.Name, $"{name}{suffix}",
                StringComparison.CurrentCultureIgnoreCase));
    }
}