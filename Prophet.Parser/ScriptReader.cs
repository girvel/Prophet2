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

        public Reader[] Readers;

        public ScriptReader()
        {
            Readers = new[]
            {
                RegexReader(
                    NpcNamePattern,
                    (m, state) =>
                    {
                        state.NpcName = m.Groups[3].Value;
                        state.Source = m.Groups[4].Value;
                    }),
                RegexReader(
                    ReplicaPattern,
                    (m, state) =>
                    {
                        if (state.NpcName == null)
                        {
                            // TODO exception
                            throw new Exception();
                        }
                    
                        state.Replica.Speaker = state.NpcName;
                        state.Replica.Text = m.Groups[2].Value;
                        state.Replica.Variants = new[] {new Variant("", new Replica()),};
                        state.Replica = state.Replica.Variants[0].Replica;
                        state.Source = m.Groups[3].Value;
                    }),
            };
        }

        

        public Replica Read(string source)
        {
            var state = new ReaderState
            {
                NpcName = null,
                Replica = new Replica(),
                Source = source,
            };
            
            var root = state.Replica;
            string npcName = null;
            
            while (!EndPattern.IsMatch(state.Source))
            {
                var read = false;
                foreach (var reader in Readers)
                {
                    if (reader(state))
                    {
                        read = true;
                        break;
                    }
                }
            
                // TODO exception
                if (!read) throw new Exception();
            }

            return root;
        }

        private Reader RegexReader(Regex r, Action<Match, ReaderState> action)
        {
            return state =>
            {
                var match = r.Match(state.Source);

                if (match.Success) action(match, state);

                return match.Success;
            };
        }
    }
}