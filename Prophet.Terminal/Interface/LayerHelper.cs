using System;
using System.Linq;
using Province.Vector;

namespace Prophet.Terminal.Interface
{
    public static class LayerHelper
    {
        public static T[,] ToTwoDimensional<T>(this T[][] arr)
        {
            var result = new T[arr.Max(a => a.Length), arr.Length];

            foreach (var position in result.Size().Range())
            {
                result.SetAt(position, position.X < arr[position.Y].Length ? arr.GetAt(position) : default(T));
            }

            return result;
        }
        
        public static Atom[,] Overlay(this Atom[,] previous, Atom[,] next)
        {
            var size = Vector.PartialMax(previous.Size(), next.Size());
            var result = size.CreateArray<Atom>();
            
            foreach (var position in size.Range())
            {
                result.SetAt(
                    position,
                    position.IsInside(next.Size()) && next.GetAt(position) != null
                        ? next.GetAt(position) 
                        : position.IsInside(previous.Size()) 
                            ? previous.GetAt(position) 
                            : null);
            }

            return result;
        }
    }
}