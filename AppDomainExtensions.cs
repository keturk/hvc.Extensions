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

public static class AppDomainExtensions
{
    /// <summary>
    ///     Get All Classes with specified attribute in an AppDomain
    /// 
    ///     This method can be used to find all classes in an appDomain
    ///     that have a specific attribute applied to them. For example,
    ///     if the attributeType parameter is set to typeof(MyAttribute),
    ///     the method will return all classes that have the MyAttribute
    ///     attribute applied to them.
    /// </summary>
    /// <param name="appDomain">AppDomain</param>
    /// <param name="attributeType">Attribute type that is </param>
    /// <returns>List of types with specified class attribute</returns>
    public static IEnumerable<Type> GetClassesByAttribute(this AppDomain appDomain, Type attributeType)
    {
        return (from assembly in appDomain.GetAssemblies()
            from type in assembly.GetTypes()
            let attributes = type.GetCustomAttributes(false)
            from attr in attributes
            where attr.GetType() == attributeType
            select type).ToList();
    }

    /// <summary>
    ///     The method searches for a type in the appDomain that is a subclass of the given baseType
    ///     and has a name that matches the given name plus the suffix, ignoring case. The method
    ///     returns the matching type if it is found, or null if no matching type is found.
    /// </summary>
    /// <param name="appDomain"></param>
    /// <param name="baseType"></param>
    /// <param name="name"></param>
    /// <param name="prefix">Optional prefix</param>
    /// <param name="suffix">Optional suffix</param>
    /// <returns></returns>

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