using System.Collections.Generic;
using System;

namespace Tsonic.JSRuntime
{
    /// <summary>
    /// Static JavaScript Array helpers exposed through the global Array object.
    /// Instance methods remain on JSArray&lt;T&gt;.
    /// </summary>
    public static class JSArrayStatics
    {
        public static bool isArray(object? value)
        {
            if (value is Array) return true;
            var type = value?.GetType();
            return type?.IsGenericType == true &&
                   type.GetGenericTypeDefinition() == typeof(JSArray<>);
        }

        public static JSArray<T> from<T>(IEnumerable<T> iterable)
        {
            return JSArray<T>.from(iterable);
        }

        public static JSArray<string> from(string source)
        {
            var chars = new string[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                chars[i] = source[i].ToString();
            }

            return new JSArray<string>(chars);
        }

        public static JSArray<TResult> from<TSource, TResult>(
            IEnumerable<TSource> iterable,
            System.Func<TSource, int, TResult> mapFunc
        )
        {
            return JSArray<TResult>.from(iterable, mapFunc);
        }

        public static JSArray<TResult> from<TResult>(
            string source,
            System.Func<string, int, TResult> mapFunc
        )
        {
            var result = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                result[i] = mapFunc(source[i].ToString(), i);
            }

            return new JSArray<TResult>(result);
        }

        public static JSArray<T> of<T>(params T[] items)
        {
            return JSArray<T>.of(items);
        }
    }
}
