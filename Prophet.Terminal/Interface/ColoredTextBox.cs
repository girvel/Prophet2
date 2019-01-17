using System;
using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class ColoredTextBox : ILayer
    {
        public ColoredString Value { get; set; }

        public int Width { get; set; } = 60;

        public ColoredTextBox()
        {
            Value = new ColoredString();
        }

        public ColoredTextBox(ColoredString value)
        {
            Value = value;
        }
        
        public Atom[,] GetState()
        {
            return _getState().ToTwoDimensional();
        }

        protected virtual Atom[][] _getState()
        {
            return Value
                .Split('\n')
                .SelectMany(l => l.Any()
                    ? Enumerable
                        .Range(0, (int) Math.Ceiling(l.InternalArray.Length / (double) Width))
                        .Select(i => l.Skip(i * Width).Take(Width).ToArray())
                    : new[] {l.InternalArray})
                .ToArray();
        }
    }
}