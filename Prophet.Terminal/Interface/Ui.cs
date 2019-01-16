using System;
using Prophet.Core;

namespace Prophet.Terminal.Interface
{
    public class Ui
    {
        private string _lastSpeaker;
        
        public void ShowReplica(Replica replica)
        {
            if (replica.Speaker != _lastSpeaker)
            {
                ExtendedConsole.WriteLine();
                ExtendedConsole.WriteLine(replica.Speaker, ConsoleColor.Black, ConsoleColor.Gray);
            }
            
            ExtendedConsole.WriteLine(replica.Text, ConsoleColor.White);
            
            _lastSpeaker = replica.Speaker;
        }
    }
}