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

public static class TypeExtensions
{
    /// <summary>
    ///     Checks whether currentType can be treated as typeToCompareWith.
    ///     The method first checks whether either of the input types is null. If either of them is, it returns false. If both
    ///     types are not null, it uses the IsAssignableFrom() method of the typeToCompareWith object to check whether
    ///     currentType is a subclass or implementer of typeToCompareWith, or is the same type as typeToCompareWith.If
    ///     currentType satisfies either of these conditions, the method returns true. Otherwise, it returns false.
    /// </summary>
    /// <param name="currentType"></param>
    /// <param name="typeToCompareWith"></param>
    /// <returns></returns>
    public static Boolean CanBeTreatedAsType(this Type? currentType, Type? typeToCompareWith)
    {
        return currentType != null && typeToCompareWith != null && typeToCompareWith.IsAssignableFrom(currentType);
    }

    /// <summary>
    ///     Gets the inheritance hierarchy of `type`, up to `baseType`.
    ///     The method creates a new empty list of Type objects called types. It then iterates over the inheritance hierarchy
    ///     of `type`, starting from `type` itself and going up to its base type, using a for loop.For each type in the
    ///     hierarchy, it adds the type to the list.If the current type is the same as the base type, the loop is broken.
    /// 
    ///     Finally, the method reverses the order of the types in the list (so that the base type is at the beginning of the
    ///     list) and returns the list.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="baseType"></param>
    /// <returns></returns>
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