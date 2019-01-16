using System;
using System.IO;
using System.Linq;
using Prophet.Core;
using Prophet.Parser;
using Prophet.Terminal.Interface;

namespace Prophet.Terminal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ui = new Ui();

            var currentReplica = GetScript();
            while (currentReplica?.Variants?.Any() ?? false)
            {
                ui.ShowReplica(currentReplica);
                Console.ReadKey(true);

                currentReplica = currentReplica.Variants.First().Replica;
            }
            
            Console.WriteLine("...");
            Console.ReadKey(true);
        }



        private static Replica GetScript()
        {
            string data;
            
            using (var stream = File.OpenRead(@"Resources\Test script.txt"))
            using (var reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd();
            }
            
            return new ScriptReader().Read(data);
        }
    }
}