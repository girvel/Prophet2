using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class StringLayer : ILayer
    {
        public string Value { get; set; }

        public StringLayer(string value)
        {
            Value = value;
        }
        
        public Atom[,] GetState()
        {
            return Value
                .Split('\n')
                .Select(l => l.Select(c => new Atom{Character = c}).ToArray())
                .ToArray()
                .ToTwoDimensional();
        }
    }
}