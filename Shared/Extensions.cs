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

        public static void WriteCollection<T>(this IEnumerable<T> enumerable,
            ConsoleColor bracketColor = ConsoleColor.White,
            ConsoleColor elementColor = ConsoleColor.Cyan,
            ConsoleColor warningColor = ConsoleColor.DarkYellow,
            ConsoleColor seperatorColor = ConsoleColor.DarkGray)
        {
            if (enumerable is null)
            {
                Console.Write('[');
                Console.ForegroundColor = warningColor;
                Console.Write("null");
                Console.ForegroundColor = bracketColor;
                Console.Write(']');
                Console.WriteLine();
            }
            else if (!enumerable.Any())
            {
                Console.WriteLine("[]");
            }
            else
            {
                //Console.BackgroundColor = ConsoleColor.DarkGreen;
                //Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write('[');
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    Console.ForegroundColor = elementColor;
                    Console.Write(enumerable.ElementAt(i));
                    if (!(i == enumerable.Count() - 1))
                    {
                        Console.ForegroundColor = seperatorColor;
                        Console.Write(',');
                    }
                }
                Console.ForegroundColor = bracketColor;
                Console.Write(']');
                Console.WriteLine();
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
