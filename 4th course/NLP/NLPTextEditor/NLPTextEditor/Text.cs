namespace NLPTextEditor
{
    public class Text
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int IsTagged { get; set; } //It's bool. SQLite doesn't support bool.

        public Text() { }

        public Text(string path)
        {
            Path = path;
            IsTagged = 0;
        }
    }
}
