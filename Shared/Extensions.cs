using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class Extensions
    {
        //Short syntax to write out a collection
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }
        /*public static IEnumerable<T> Prepend<T>(
            this IEnumerable<T> values, T value)
        {
            yield return value;
            foreach (var item in values)
                yield return item;
        }*/
    }

}
