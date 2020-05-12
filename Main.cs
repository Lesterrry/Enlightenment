/***************************
COPYRIGHT FETCH DEVELOPMENT,
2020
Enlightenment – COLLECTION
OF NUMEROUS HANDY METHODS
FOR UNIVERSAL PURPOSES
VERSION 1.1

LESTERRRY AUTHORSHIP
***************************/
using System;
namespace FetchDev
{
    namespace Enlightenment
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
                if (offset) Console.CursorLeft = Console.CursorLeft - (data.Length - 1);
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
            public static int interpretateConsoleKeyNum(ConsoleKey key)
            {
                string a = key.ToString();
                return int.Parse(a.Replace("D", ""));
            }
            public static int intAppend(int a, int b)
            {
                return int.Parse(a.ToString() + b.ToString());
            }
            public static bool isNumber(char input)
            {
                return int.TryParse(input.ToString(), out _);
            }
            public static bool isNumber(string input)
            {
                return int.TryParse(input, out _);
            }
            public static type pickRandom<type>(type[] arr, int min = 0)
            {
                Random random = new Random();
                return arr[random.Next(min, arr.Length)];
            }
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
            public static int getMaxLength(string[] arr)
            {
                int a = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length > a) a = arr[i].Length;
                }
                return a;
            }

        }
        public class ConsoleMenu
        {
            public string[] menuElements;
            public string[] secondLayerElements;
            public string marker;
            private bool dispatched = false;
            private bool expanded = false;
            public int iOffset = -1;

            public bool isDispatched()
            {
                return dispatched;
            }
            public bool isExpanded()
            {
                return expanded;
            }
            public void dispatch()
            {
                bool setOffset = false;
                int offset = 0;
                dispatched = true;
                ConsoleColor color = Console.ForegroundColor;
                Console.CursorTop = 1;
                Console.CursorLeft = 0;
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("INTERACTIVE MENU");
                for (int i = 0; i < menuElements.Length; i++)
                {
                   if(menuElements[i] == "/")
                    {
                        iOffset = i;
                        setOffset = true;
                        for (int j = 0; j < Misc.getMaxLength(menuElements) + 5; j++)
                        {
                            Console.Write("–");
                        }
                        Console.WriteLine();
                        offset++;
                        i++;
                    }
                    if (i == 0)
                    {
                        Console.Write("˥ " + (i + 1) + ". " + menuElements[i]);
                        if (expanded) { if (i == Array.IndexOf(menuElements, marker)) inexpand(i); else Console.WriteLine(); }
                        else Console.WriteLine();
                    }
                    else if (i < menuElements.Length - 1)
                    {
                        Console.Write("| " + (i + 1) + ". " + menuElements[i]);
                        if (expanded) { if (i == Array.IndexOf(menuElements, marker)) inexpand(i); else Console.WriteLine(); }
                        else Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("˩ " + (i + 1) + ". " + menuElements[i]) ;
                        if (expanded) { if (i  == Array.IndexOf(menuElements, marker)) inexpand(i); else Console.WriteLine(); }
                        else Console.WriteLine();
                    }

                }
                if (!setOffset)
                {
                    iOffset = -1;
                }
                for (int i = 0; i < Console.BufferWidth; i++)
                {
                    Console.Write("=");
                }
                Console.ForegroundColor = color;

            }
            private void inexpand(int index)
            {
                Console.Write(" >");
                for (int i = 0; i < Misc.getMaxLength(menuElements) - menuElements[index].Length; i++)
                {
                    Console.Write("–");
                   
                }
                Console.WriteLine("¬");
                int leftReference = Console.CursorLeft;
                Console.Write(" <<< 0");
                Console.CursorTop = Console.CursorTop + 1;
                for (int i = 0; i < secondLayerElements.Length; i++)
                {
                    Console.CursorLeft = leftReference;
                    Console.CursorTop = Console.CursorTop + 1;
                    Console.Write(i < secondLayerElements.Length - 1 ? "|" : "˩");
                    Console.WriteLine((i + 1) + ". " + secondLayerElements[i]);
                }
                Console.WriteLine();
                Console.CursorLeft = 0;

            }
            public void supress()
            {
                Console.Clear();
                dispatched = false;
                expanded = false;
            }

            public void expand()
            {
                expanded = true;
            }

            public void collapse()
            {
                expanded = false;
            }

            public string getSelected(int key)
            {
               
                //if(iOffset != -1 && key > iOffset)
                //{
                //    return expanded ? secondLayerElements[key - 2] : menuElements[key - 2];
                //}
                //else
                
                    if (key != 0)
                    {
                        return expanded ? secondLayerElements[key - 1] : menuElements[key - 1];
                    }
                
                return "back";
            }
        }
    }
}
