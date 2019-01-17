using Prophet.Core;

namespace Prophet.Parser
{
    public class ReaderState
    {
        public string Source { get; set; }
        
        public Replica Replica { get; set; }
        
        public string NpcName { get; set; }
    }
}