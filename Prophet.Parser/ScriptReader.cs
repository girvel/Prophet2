using System;
using System.Linq;
using System.Text.RegularExpressions;
using Prophet.Core;

namespace Prophet.Parser
{
    public class ScriptReader
    {
        public Regex 
            NpcNamePattern = new Regex(@"^(\n{2})?(\S+[\S ]*)([\S\s]*)$"),
            ReplicaPattern = new Regex(@"^\n(\S+[\S ]*)([\S\s]*)$"),
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
                        state.NpcName = m.Groups[2].Value;
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
                        state.Replica.Text = m.Groups[1].Value;
                        state.Replica.Variants = new[] {new Variant("", new Replica()),};
                        state.Replica = state.Replica.Variants[0].Replica;
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
            
            while (!EndPattern.IsMatch(state.Source))
            {
                // TODO exception
                if (!Readers.Any(reader => reader(state))) throw new Exception();
            }

            return root;
        }

        private Reader RegexReader(Regex r, Action<Match, ReaderState> action)
        {
            return state =>
            {
                var match = r.Match(state.Source);

                if (match.Success)
                {
                    action(match, state);
                    state.Source = match.Groups.Cast<Group>().Last().Value;
                }

                return match.Success;
            };
        }
    }
}