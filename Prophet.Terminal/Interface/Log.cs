using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class Log : ColoredTextBox
    {
        public int Height { get; set; } = 10;

        protected override Atom[][] _getState()
        {
            var state = base._getState();
            return state.Skip(state.Length - Height).ToArray();
        }
    }
}