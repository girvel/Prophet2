using System;
using Prophet.Core;

namespace Prophet.Terminal.Interface
{
    public class Ui : CompositionUi
    {
        private string _lastSpeaker;
        
        public Log Log { get; } = new Log();

        public Ui()
        {
            Layers.Add(Log);
            Console.Title = "Prophet";
            Console.SetWindowSize(120, 40);
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