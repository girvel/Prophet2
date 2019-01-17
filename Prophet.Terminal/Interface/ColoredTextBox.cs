using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class ColoredTextBox : ILayer
    {
        public ColoredString Value { get; set; }
        
        public int Width { get; set; }

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
            return Value
                .Split('\n')
                .Select(l => l.InternalArray)
                .ToArray()
                .ToTwoDimensional();
        }
    }
}