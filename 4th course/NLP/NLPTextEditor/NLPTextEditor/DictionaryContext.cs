using System.Data.Entity;
using System.Linq;

namespace NLPTextEditor
{
    public class DictionaryContext : DbContext
    {
        public DictionaryContext() : base("DefaultConnection"){ }

        public DbSet<Word> Words { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public void TruncateWords() => Database.ExecuteSqlCommand("DELETE FROM [Words]");
        public void TruncateTexts() => Database.ExecuteSqlCommand("DELETE FROM [Texts]");
        public void TruncateTags() => Database.ExecuteSqlCommand("DELETE FROM [Tags]");

        public void ClearTagsStatistics()
        {
            foreach (var tag in Tags)
            {
                tag.Amount = 0;
                tag.NextTags = string.Empty;
            }

            SaveChanges();
        }

        public void AddText(Text text)
        {
            if (!Texts.Any(x => x.Path == text.Path))
            {
                Texts.Add(text);
                SaveChanges();
            }
        }
    }
}
