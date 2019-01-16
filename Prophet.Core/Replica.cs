namespace Prophet.Core
{
    public class Replica
    {
        public string Speaker { get; set; }
        
        public string Text { get; set; }
        
        public Variant[] Variants { get; set; }



        public Replica()
        {
        }

        public Replica(string speaker, string text, Variant[] variants)
        {
            Speaker = speaker;
            Text = text;
            Variants = variants;
        }
    }
}