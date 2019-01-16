using System;
using Prophet.Core;

namespace Prophet.Terminal.Interface
{
    public class Ui
    {
        public void ShowReplica(Replica replica)
        {
            ExtendedConsole.WriteLine(replica.Speaker, ConsoleColor.Black, ConsoleColor.Gray);
            ExtendedConsole.WriteLine(replica.Text, ConsoleColor.White);
            ExtendedConsole.WriteLine();
        }
    }
}