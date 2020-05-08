/***************************
COPYRIGHT FETCH DEVELOPMENT,
2020

LESTERRRY AUTHORSHIP
***************************/
using System;
namespace FetchDev
{
    namespace Enlightment
    {
        public class FastConsole
        {
            public enum Dimension
            {
                none,
                right,
                left,
                top,
                bottom,
                center
            }
            public static string readAfterColorLine(ConsoleColor color = ConsoleColor.Gray)
            {
                string result = Console.ReadLine();
                Console.ForegroundColor = color;
                return result;
            }

            public static void writeColorLine(string data, ConsoleColor color = ConsoleColor.Gray, bool offset = false)
            {
                if (offset) Console.CursorLeft = Console.CursorLeft - data.Length;
                ConsoleColor cacheColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(data);
                Console.ForegroundColor = cacheColor;
            }
            public static void writeAfterColorLine(string data, ConsoleColor color = ConsoleColor.Gray, ConsoleColor afterColor = ConsoleColor.Gray)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(data);
                Console.ForegroundColor = afterColor;
            }
            public static void writeAfterColor(string data, ConsoleColor color = ConsoleColor.Gray, ConsoleColor afterColor = ConsoleColor.Gray)
            {
                Console.ForegroundColor = color;
                Console.Write(data);
                Console.ForegroundColor = afterColor;
            }
            public static void writeColor(string data, ConsoleColor color = ConsoleColor.Gray, bool offset = false)
            {
                if (offset) Console.CursorLeft = Console.CursorLeft - data.Length;
                ConsoleColor cacheColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write(data);
                Console.ForegroundColor = cacheColor;
            }
            public static void attach(Dimension[] dimensions, string data = "")
            {
                if (Misc.arrayContains(dimensions, Dimension.left)) Console.CursorLeft = 0;
                else if (Misc.arrayContains(dimensions, Dimension.right)) Console.CursorLeft = Console.BufferWidth - 1;
                else if (Misc.arrayContains(dimensions, Dimension.center))
                {
                    Console.CursorLeft = (Console.BufferWidth / 2) - data.Length / 2;
                }
                if (Misc.arrayContains(dimensions, Dimension.top)) Console.CursorTop = 0;
                else if (Misc.arrayContains(dimensions, Dimension.bottom)) Console.CursorTop = Console.BufferHeight - 1;
            }

        }
        public class Misc
        {
            public static bool arrayContains<Type>(Type[] arr, Type obj)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Equals(obj))
                    {
                        return true;
                    }
                }
                return false;
            }
            public static bool arrayContains(ref int[] arr, ref int obj)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == obj)
                    {
                        return true;
                    }
                }
                return false;
            }
            public static void arrayAppend<Type>(Type[] arr, Type obj, Type marker)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Equals(marker))
                    {
                        arr[i] = obj;
                        break;
                    }
                }
            }
            public static void arrayFill<Type>(Type[] arr, Type obj)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = obj;
                }
            }

        }
    }
}
