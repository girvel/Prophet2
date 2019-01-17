using System;
using Prophet.Core;

namespace Prophet.Terminal.Interface
{
    public class Ui : CompositionUi
    {
        private string _lastSpeaker;
        
        public ColoredTextBox Log { get; } = new ColoredTextBox();

        public Ui()
        {
            Layers.Add(Log);
        }
        
        public void ShowReplica(Replica replica)
        {
            if (replica.Speaker != _lastSpeaker)
            {
                Log.Value += $"\n{replica.Speaker}\n".Color(ConsoleColor.Black, ConsoleColor.Gray);
            }
            
            Log.Value += (replica.Text + "\n").Color(ConsoleColor.White);
            Display();
            
            _lastSpeaker = replica.Speaker;
        }
    }
}