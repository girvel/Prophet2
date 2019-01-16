namespace Prophet.Core
{
    public class Variant
    {
        public string Text { get; set; }
        
        public Replica Replica { get; set; }



        public Variant()
        {
        }
        
        public Variant(string text, Replica replica)
        {
            Text = text;
            Replica = replica;
        }
    }
}