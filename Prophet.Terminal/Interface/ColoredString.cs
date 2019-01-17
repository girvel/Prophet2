using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class ColoredString : IEnumerable<Atom>
    {
        public Atom[] InternalArray { get; set; } = new Atom[0];



        public ColoredString()
        {
        }
        
        public ColoredString(params Atom[] internalArray)
        {
            InternalArray = internalArray;
        }


        public IEnumerator<Atom> GetEnumerator()
        {
            return InternalArray.Cast<Atom>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalArray.GetEnumerator();
        }


        
        public override string ToString() =>
            $"[{GetType().Name}: \"{InternalArray.Aggregate("", (sum, a) => sum + a.Character)}\"]";
        
        
        
        public static ColoredString operator +(ColoredString c1, ColoredString c2) 
            => new ColoredString{InternalArray = c1.InternalArray.Concat(c2.InternalArray).ToArray()};

        public static ColoredString operator +(ColoredString c, Atom a)
            => c + new ColoredString {InternalArray = new[] {a}};
    }
}