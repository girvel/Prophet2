using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Prophet.Core;

namespace Prophet.Parser
{
    public class ScriptReader
    {
        public Regex ReplicaRecursivePattern = new Regex(@"^\s*(\S+[\S ]*)\r?\n(\S+[\S ]*)\r?\n([\S\s]*)$");
        
        
        
        public Replica Read(string source)
        {
            var match = ReplicaRecursivePattern.Match(source);
            return match.Success
                ? new Replica(
                    match.Groups[1].Value,
                    match.Groups[2].Value,
                    new[] {new Variant("", Read(match.Groups[3].Value)),})
                : null;
        }
    }
}