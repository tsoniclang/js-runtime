using System.Collections.Generic;
using System.Linq;
using Tsonic.Runtime;

namespace Tsonic.JSRuntime;

/// <summary>
/// JavaScript Object static helpers.
/// </summary>
public static class Object
{
    private static IEnumerable<KeyValuePair<string, object?>> Enumerate(object? value)
    {
        if (value == null)
            return [];

        if (value is DynamicObject dynamicObject)
        {
            return dynamicObject.GetKeys().Select(key => new KeyValuePair<string, object?>(key, dynamicObject[key]));
        }

        if (value is IDictionary<string, object?> dictionary)
            return dictionary;

        return Structural.ToDictionary(value);
    }

    public static string[] keys(object? value)
    {
        return Enumerate(value).Select(pair => pair.Key).ToArray();
    }

    public static object?[] values(object? value)
    {
        return Enumerate(value).Select(pair => pair.Value).ToArray();
    }

    public static (string key, object? value)[] entries(object? value)
    {
        return Enumerate(value).Select(pair => (pair.Key, pair.Value)).ToArray();
    }
}
