using System;
using System.Collections.Generic;
using System.Linq;

namespace Prophet.Terminal.Interface
{
    public static class ColoredStringHelper
    {
        public static ColoredString Color(
            this string str, ConsoleColor foreground, ConsoleColor background = ConsoleColor.Black)
        {
            return new ColoredString{InternalArray = str.Select(c => new Atom(c, foreground, background)).ToArray()};
        }

        public static ColoredString[] Split(this ColoredString str, char character)
        {
            var result = new List<ColoredString>{new ColoredString()};

            foreach (var atom in str)
            {
                if (atom.Character == character)
                {
                    result.Add(new ColoredString());
                    continue;
                }
                
                result[result.Count - 1] += atom;
            }

            return result.ToArray();
        }
    }
}