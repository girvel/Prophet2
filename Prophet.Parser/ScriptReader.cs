using System;
using System.Text.RegularExpressions;
using Prophet.Core;

namespace Prophet.Parser
{
    public class ScriptReader
    {
        public Regex 
            NpcNamePattern = new Regex(@"^((\r?\n){2})?(\S+[\S ]*)(\r?\n[\S\s]*)$"),
            ReplicaPattern = new Regex(@"^(\r?\n)(\S+[\S ]*)(\r?\n[\S\s]*)$"),
            EndPattern = new Regex(@"^\s*$");
        
        
        
        public Replica Read(string source)
        {
            var replica = new Replica();
            var root = replica;
            string npcName = null;
            
            while (!EndPattern.IsMatch(source))
            {
                var match = NpcNamePattern.Match(source);

                if (match.Success)
                {
                    npcName = match.Groups[3].Value;
                    source = match.Groups[4].Value;
                    continue;
                }

                match = ReplicaPattern.Match(source);

                if (match.Success)
                {
                    if (npcName == null)
                    {
                        // TODO exception
                        throw new Exception();
                    }
                    
                    replica.Speaker = npcName;
                    replica.Text = match.Groups[2].Value;
                    replica.Variants = new[] {new Variant("", new Replica()),};
                    replica = replica.Variants[0].Replica;
                    source = match.Groups[3].Value;
                    continue;
                }
            
                // TODO exception
                throw new Exception();
            }

            return root;
        }
    }
}